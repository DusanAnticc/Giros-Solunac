using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Timers;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace fastfoodsolunacnew
{
    class AzurirajPrviRac
    {
        ReaderWriterLock locker = new ReaderWriterLock();
        private BackgroundWorker worker;
        public Form1 Main;

        public AzurirajPrviRac(Form1 forma)
        {
            Main = forma;
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!worker.IsBusy)
                worker.RunWorkerAsync();
        }
      
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (FileStream stream = new FileStream(Form1.MyGlobals.azurirajPrviRacunar, FileMode.Open,FileAccess.Read,FileShare.ReadWrite))
            {
                using (TextReader tr = new StreamReader(stream))
                {
                    string line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        //Main.upisiAktivniGirosUFajl(new numberOdGirosInOrder(Main.counter, int.Parse(line.Split(',')[1])));
                        //Main.aktivniGirosi.Add(new numberOdGirosInOrder(Main.counter, int.Parse(line.Split(',')[1])));
                        //Main.dodajUAktivneNarudzbe(Main.activeOrderPanel.form, true, Main.counter);
                        //Main.numberOfGiros.Add(new numberOdGirosInOrder(Main.counter, int.Parse(line.Split(',')[1])));

                        //Main.addOnButton68(line.Split(',')[1]);

                        //Main.counter++;
                        //Main.izmjeniDatumFajl();
                        Main.upisiAktivniGirosUFajl(new numberOdGirosInOrder(int.Parse(line.Split(',')[0]), int.Parse(line.Split(',')[1])));
                        Main.aktivniGirosi.Add(new numberOdGirosInOrder(int.Parse(line.Split(',')[0]), int.Parse(line.Split(',')[1])));
                        Main.dodajUAktivneNarudzbe(Main.activeOrderPanel.form, true, int.Parse(line.Split(',')[0]));
                        Main.numberOfGiros.Add(new numberOdGirosInOrder(int.Parse(line.Split(',')[0]), int.Parse(line.Split(',')[1])));

                        Main.addOnButton68(line.Split(',')[1]);
                    }
                }
            }

            using (var fs = new FileStream(Form1.MyGlobals.azurirajPrviRacunar, FileMode.Truncate))
            {
            }
        }
    }
}
