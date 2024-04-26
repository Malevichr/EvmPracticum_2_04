using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using org.matheval;

namespace EvmPracticum_2_04_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in MainRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            try
            {
                if (str == "AC")
                    textLabel.Text = "";
                else if (str == "C")

                    textLabel.Text = textLabel.Text.Substring(0, textLabel.Text.Length - 1);
                else if (str == "=")
                    textLabel.Text += " = " + MyCompute(textLabel.Text);
                else
                    textLabel.Text += str;
            }
            catch {}
            
        }
        public string? MyCompute(String stirngExpression)
        {
            org.matheval.Expression expression = new org.matheval.Expression(stirngExpression);
            Object value = expression.Eval();
            
            return value.ToString();
        }
    }
    
}
