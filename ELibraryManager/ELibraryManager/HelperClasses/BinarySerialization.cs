using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ELibraryManager.ViewModel;

namespace ELibraryManager.HelperClasses
{
    class BinarySerialization
    {
        public async Task Serialize()
        {
            SaveFile saveFile = new SaveFile();
            saveFile.books = BookViewModel.books;
            saveFile.users = UserViewModel.Users;

            FileStream fs = new FileStream("SaveFile.bin", FileMode.Create, FileAccess.Write);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, saveFile);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("File can not be saved", "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public void Deserialize()
        {
            SaveFile saveFile = null;

            FileStream fs = null;
   
            try
            {
                fs = new FileStream("SaveFile.bin", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();

                saveFile = (SaveFile) formatter.Deserialize(fs);
                BookViewModel.books = saveFile.books;
                UserViewModel.Users = saveFile.users;

                if (MainWindow.GetMainViewModel() != null) MainWindow.GetMainViewModel().refreshDataView();
            }
            catch (SerializationException e)
            {
                MessageBox.Show("File can not be open", "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine("[E_Library]" + " " + DateTime.Now.ToShortTimeString() + " "+ "File does not exists");
                throw;
            }
            finally
            {
                if(fs != null)
                fs.Close();
            }
        }

        private async Task PeriodicallySaveThread()
        {

            Stopwatch stopwatch = Stopwatch.StartNew();

            while (true)
            {
                // react every five minutes
                if (stopwatch.ElapsedMilliseconds == 60000)
                {
                    Debug.WriteLine("[E_Library]" + " " + DateTime.Now.ToShortTimeString() + " "+ "FileData saved");
                    await Serialize();
                    stopwatch.Reset();
                    stopwatch.Start();
                }
            }
        }

        public async Task SaveFilePeriodically()
        {
            await PeriodicallySaveThread();
        }
    }
}
