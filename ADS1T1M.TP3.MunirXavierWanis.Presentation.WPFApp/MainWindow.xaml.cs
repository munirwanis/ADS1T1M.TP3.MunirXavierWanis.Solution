using ADS1T1M.TP3.MunirXavierWanis.Infra.Data.Contexts;
using System;
using System.Windows;
using System.Windows.Media;

namespace ADS1T1M.TP3.MunirXavierWanis.Presentation.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TxtBl_InfoMessage.Visibility = Visibility.Hidden;
        }

        private void btn_search_enrollment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var alunoContext = new AlunoContext();
                var aluno = alunoContext.GetAluno(Txt_Enrollment.Text);

                if (aluno == null)
                {
                    this.Clear();
                    TxtBl_InfoMessage.Text = "Aluno não Encontrado";
                    TxtBl_InfoMessage.Background = Brushes.Blue;
                    TxtBl_InfoMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    TxtBl_BirthdateValue.Text = aluno.BirthdateField;
                    TxtBl_CpfValue.Text = aluno.Cpf;
                    TxtBl_EnrollmentValue.Text = aluno.Enrollment;
                    TxtBl_NameValue.Text = aluno.Name;
                    if (aluno.Enabled)
                    {
                        TxtBl_InfoMessage.Text = "Liberado";
                        TxtBl_InfoMessage.Background = Brushes.Green;
                        TxtBl_InfoMessage.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        TxtBl_InfoMessage.Text = "Suspenso";
                        TxtBl_InfoMessage.Background = Brushes.Red;
                        TxtBl_InfoMessage.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.LogException(ex);
                TxtBl_InfoMessage.Text = "Erro";
                TxtBl_InfoMessage.Background = Brushes.Red;
                TxtBl_InfoMessage.Visibility = Visibility.Visible;
            }
        }

        private void Txt_Enrollment_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            this.Clear();
        }

        private void Clear()
        {
            TxtBl_BirthdateValue.Text = string.Empty;
            TxtBl_CpfValue.Text = string.Empty;
            TxtBl_EnrollmentValue.Text = string.Empty;
            TxtBl_NameValue.Text = string.Empty;
            TxtBl_InfoMessage.Visibility = Visibility.Hidden;
        }
    }
}
