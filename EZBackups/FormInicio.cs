using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;


namespace EZBackups
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        //Diseñar icon

        List<string> carpetas_borrar = new List<string>();
        List<string> carpetas_analizar = new List<string>();
        bool cambios;

        //PROCESO

        private void Ejecutar()
        {
            //Declaramos variables
            int i;
            DirectoryInfo di;
            try
            {
                //Comprobamos que exista el directorio inicial dado por el usuario
                if (Directory.Exists(frmMain.frm_Main.Config.ruta))
                {
                    cambios = false;

                    #region Analizamos Carpetas
                    //Arrancamos analisis
                    di = new DirectoryInfo(frmMain.frm_Main.Config.ruta);
                    AnalizarDirectorio(di);

                    //Comprobamos todas las carpetas pendientes de analizar
                    while (carpetas_analizar.Count > 0)
                    {
                        carpetas_borrar.Clear();                      //Vaciamos nuestra lista de carpetas analizadas

                        for (i = 0; i < carpetas_analizar.Count; i++) //Recorremos la lista de carpetas pendientes de analizar
                        {
                            di = new DirectoryInfo(carpetas_analizar[i]);
                            AnalizarDirectorio(di);

                            carpetas_borrar.Add(carpetas_analizar[i]); //Añadimos este directorio a la lista de carpetas analizadas
                        }

                        //Borramos de la lista de carpetas pendientes de analizar las carpetas que fueron analizadas
                        foreach (string item in carpetas_borrar)
                        {
                            carpetas_analizar.Remove(item);
                        }

                        carpetas_borrar.Clear();//Vaciamos nuestra lista de carpetas analizadas
                    }

                    #endregion

                    //Si se ha realizado algun cambio mostramos notificación y actualizamos log.txt
                    if (cambios == true)
                    {
                        notificacionAviso.BalloonTipText = "Se han realizado modificaciones en los archivos";
                        notificacionAviso.ShowBalloonTip(2500);
                        File.WriteAllText(Application.StartupPath + "\\log.txt", richTextBox1.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                frmMain.frm_Main.Aviso("Esto no ha debido ocurrir.\nRevisa el formulario de configuración y vuelve a intentarlo\n" + ex);
                btnStart.PerformClick();
            }
        }

        private void AnalizarDirectorio(DirectoryInfo di)
        {
            //Declaramos variables
            bool isNumber;
            int fecha;

            //Obtenemos todas las carpetas del directorio recibido
            foreach (var carpeta in di.GetDirectories())
            {
                //Comprobamos si el inicio del nombre de la carpeta es un numero
                if (carpeta.Name.Length > 9)
                {
                    isNumber = int.TryParse(carpeta.Name.Substring(0, 8), out fecha);
                }
                else
                {
                    isNumber = false;
                }



                //Comprobamos si es un numero seguido de una "_"
                if (isNumber && carpeta.Name.Substring(8, 1) == "_")
                {
                    //Comprobamos si la carpeta tiene una version mas reciente
                    if (EsBackup(di,carpeta.Name,true))
                    {
                        //Añadimos la ruta de la carpeta en la lista carpetas_archivar
                        MoverBackup(di, carpeta.Name, true);
                    }
                    
                }
                else
                {
                    if (carpeta.Name != "Backup")
                    {
                        //Añadimos la ruta de la carpeta en la lista carpetas_analizar
                        carpetas_analizar.Add(carpeta.FullName);
                    }
                }
            }

            //Obtenemos todos los archivos del directorio recibido
            foreach (var archivo in di.GetFiles())
            {
                //Comprobamos si el inicio del nombre del archivo es un numero
                if (archivo.Name.Length > 9)
                {
                    isNumber = int.TryParse(archivo.Name.Substring(0, 8), out fecha);
                }
                else
                {
                    isNumber = false;
                }

                //Comprobamos si es un numero seguido de una "_"
                if (isNumber && archivo.Name.Substring(8, 1) == "_")
                {
                    //Añadimos la ruta de la carpeta en la lista archivos_archivar
                    if (EsBackup(di, archivo.Name, false))
                    {
                        //Añadimos la ruta de la carpeta en la lista carpetas_archivar
                        MoverBackup(di, archivo.Name, false);
                    }
                }
            }
        }

        private bool EsBackup(DirectoryInfo di, string nombre, bool esCarpeta)
        {
            try
            {
                if (esCarpeta)
                {
                    foreach (var carpeta in di.GetDirectories())
                    {
                        if ((carpeta.Name.Length > 9) && (carpeta.Name.Substring(9, carpeta.Name.Length - 9) == nombre.Substring(9, carpeta.Name.Length - 9)))
                        {
                            try
                            {
                                if (Convert.ToInt32(nombre.Substring(0, 8)) < Convert.ToInt32(carpeta.Name.Substring(0, 8)))
                                {
                                    return true;
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                else
                {
                    foreach (var archivo in di.GetFiles())
                    {
                        if ((archivo.Name.Length > 9) && (archivo.Name.Substring(9, archivo.Name.Length - 9) == nombre.Substring(9, archivo.Name.Length - 9)))
                        {
                            try
                            {
                                if (Convert.ToInt32(nombre.Substring(0, 8)) < Convert.ToInt32(archivo.Name.Substring(0, 8)))
                                {
                                    return true;
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void MoverBackup(DirectoryInfo di, string nombre, bool esCarpeta)
        {
            DialogResult respuesta;

            //Preguntamos si se quiere archivar el posible backup encontrado
            if (frmMain.frm_Main.Config.preguntar)
            {
                respuesta = MessageBox.Show("Deseas archivar el documento " + nombre + "?", "Atención! Posible backup detectado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }
            else
            {
                respuesta = DialogResult.Yes;
            }

            
            if (respuesta == DialogResult.Yes)
            {
                //Creamos carpeta Backup si no existiera
                if (!Directory.Exists(di.ToString() + "\\Backup"))
                {
                    Directory.CreateDirectory(di.ToString() + "\\Backup");
                }

                //Movemos el backup encontrado a la carpeta de Backup
                Directory.Move(di.ToString() + "\\" + nombre, di.ToString() + "\\Backup\\" + nombre);

                //Comprobamos si hay que comprimir el backup archivado
                if (frmMain.frm_Main.Config.comprimir);
                {
                    if(esCarpeta==false && nombre.Substring(nombre.Length - 4, 4) != ".zip")
                    {
                        ZipFile zip = new ZipFile();
                        zip.AddFile(di.ToString() + "\\Backup\\" + nombre, "");
                        zip.Save(di.ToString() + "\\Backup\\" + nombre + ".zip");
                        File.Delete(di.ToString() + "\\Backup\\" + nombre);
                    }
                    else if(esCarpeta==true)
                    {
                        ZipFile zip = new ZipFile();
                        zip.AddDirectory(di.ToString() + "\\Backup\\" + nombre, "");
                        zip.Save(di.ToString() + "\\Backup\\" + nombre + ".zip");
                        Directory.Delete(di.ToString() + "\\Backup\\" + nombre);
                    }
                   
                }

                cambios = true; //Confirmamos que se han realizado cambios en este scan de backups

                //Actualizamos el log del richTextBox
                richTextBox1.Text = richTextBox1.Text + "[" + DateTime.Now + "]" + " Se ha movido el archivo '" + nombre + "' a la carpeta '" + di.ToString() + "\\Backup\\' \n\n";
            }  

        }

        //EVENTOS INTERFAZ
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Comprobamos estado del programa
            if (timer1.Enabled == false)
            {
                if (Directory.Exists(frmMain.frm_Main.Config.ruta))
                {
                    btnStart.BackColor = Color.Red;
                    btnStart.Text = "STOP";
                    timer1.Start();
                    Ejecutar();
                }
                else
                {
                    MessageBox.Show("Introduce un directorio valido en la pantalla de configuración!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                timer1.Stop();
                btnStart.BackColor = Color.DarkGray;
                btnStart.Text = "START";
            }

        }

        private void FormInicio_Shown(object sender, EventArgs e)
        {
            //Cargamos log existente
            if(File.Exists(Application.StartupPath + "\\log.txt"))
            {
                richTextBox1.LoadFile(Application.StartupPath + "\\log.txt", RichTextBoxStreamType.PlainText);
            }
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("Estas seguro de que quieres eliminar todo el log existente del programa? \n Recuerda que esta acción es irreversible","Atención!",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);
            if(respuesta == DialogResult.Yes)
            {
                File.Delete(Application.StartupPath + "\\log.txt");
                richTextBox1.Text = "";
            }
        }
    }
}
