using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApplication1.View
{
    /// <summary>
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        public NewGameWindow()
        {
            InitializeComponent();
            SetHangmanImagesList();
            ChangeHangmanImage();
        }

        public string[] RiversList = System.IO.File.ReadAllLines(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanWordsCategories/Rivers.txt");

        public string[] SeasList = System.IO.File.ReadAllLines(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanWordsCategories/Seas.txt");

        public string[] StatesList = System.IO.File.ReadAllLines(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanWordsCategories/States.txt");

        public string[] AllList = System.IO.File.ReadAllLines(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanWordsCategories/All Categories.txt");

        string word = "";
        List<Label> labels = new List<Label>();
        int wrongLetters = 0;
        Uri UriImage;
        BitmapImage CurrentHangmanImage;
        public List<string> HangmanImages = new List<string>();

        public void SetHangmanImagesList()
        {
            HangmanImages.Add(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanHangImages/stage1.JPG");
            HangmanImages.Add(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanHangImages/stage2.PNG");
            HangmanImages.Add(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanHangImages/stage3.PNG");
            HangmanImages.Add(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanHangImages/stage4.PNG");
            HangmanImages.Add(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanHangImages/stage5.PNG");
            HangmanImages.Add(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanHangImages/stage6.PNG");
            HangmanImages.Add(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanHangImages/stage7.PNG");

        }
        public void ChangeHangmanImage()
        {
            if (UriImage == null)
            {
                UriImage = new Uri(HangmanImages[0]);
                HangmanImage.Source = new BitmapImage(UriImage);
            }
            else if (UriImage == (new Uri(HangmanImages[0])))
            {
                UriImage = new Uri(HangmanImages[1]);
                HangmanImage.Source = new BitmapImage(UriImage);

            }
            else if (UriImage == (new Uri(HangmanImages[1])))
            {
                UriImage = new Uri(HangmanImages[2]);
                HangmanImage.Source = new BitmapImage(UriImage);

            }
            else if (UriImage == (new Uri(HangmanImages[2])))
            {
                UriImage = new Uri(HangmanImages[3]);
                HangmanImage.Source = new BitmapImage(UriImage);

            }
            else if (UriImage == (new Uri(HangmanImages[3])))
            {
                UriImage = new Uri(HangmanImages[4]);
                HangmanImage.Source = new BitmapImage(UriImage);

            }
            else if (UriImage == (new Uri(HangmanImages[4])))
            {
                UriImage = new Uri(HangmanImages[5]);
                HangmanImage.Source = new BitmapImage(UriImage);

            }
            else if (UriImage == (new Uri(HangmanImages[5])))
            {
                UriImage = new Uri(HangmanImages[6]);
                HangmanImage.Source = new BitmapImage(UriImage);

            }

            //CurrentHangmanImage.BeginInit();
            //CurrentHangmanImage.UriSource = new Uri(HangmanImages[0]);
            //CurrentHangmanImage.EndInit();
            //HangmanImage.Source = CurrentHangmanImage;

        }

        public string GetRandomWord()
        {
            Random random = new Random();
            String randomWord = "";
            if (RiversCategory.IsChecked == true)
            {
                randomWord = RiversList[random.Next(0, RiversList.Length - 1)];
            }
            else if (SeasCategory.IsChecked == true)
            {
                randomWord = SeasList[random.Next(0, SeasList.Length - 1)];
            }
            else if (StatesCategory.IsChecked == true)
            {
                randomWord = StatesList[random.Next(0, StatesList.Length - 1)];
            }
            else if (AllCategories.IsChecked == true)
            {
                randomWord = AllList[random.Next(0, AllList.Length - 1)];
            }

            return randomWord;
        }

        public void MakeLabels()
        {
            word = GetRandomWord();
            MessageBox.Show(word);
            char[] chars = word.ToCharArray();
            int between = 350 / chars.Length - 1;
            for (int i = 0; i < chars.Length; i++)
            {

                labels.Add(new Label());
                labels[i].Content = "_";
                int n = (i * between) + 10;
                labels[i].Height = 16;
                labels[i].Width = 15;
                labels[i].Padding = new Thickness(5, 0, 0, 0);
                labels[i].Margin = new Thickness(n, 220, 0, 0);
                Grid.Children.Add(labels[i]);

            }
        }

        private void AllCategories_Click(object sender, RoutedEventArgs e)
        {
            MakeLabels();
        }

        private void StatesCategory_Click(object sender, RoutedEventArgs e)
        {
            MakeLabels();
        }

        private void RiversCategory_Click(object sender, RoutedEventArgs e)
        {
            MakeLabels();
        }

        private void SeasCategory_Click(object sender, RoutedEventArgs e)
        {
            MakeLabels();
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            A.IsEnabled = false;
            string letter = A.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();


            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }

        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            B.IsEnabled = false;
            string letter = B.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
              
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }

        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            C.IsEnabled = false;
            string letter = C.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
               
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void D_Click(object sender, RoutedEventArgs e)
        {
            D.IsEnabled = false;
            string letter = D.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            E.IsEnabled = false;
            string letter = E.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void F_Click(object sender, RoutedEventArgs e)
        {
            F.IsEnabled = false;
            string letter = F.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
               
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void G_Click(object sender, RoutedEventArgs e)
        {
            G.IsEnabled = false;
            string letter = G.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void H_Click(object sender, RoutedEventArgs e)
        {
            H.IsEnabled = false;
            string letter = H.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void I_Click(object sender, RoutedEventArgs e)
        {
            I.IsEnabled = false;
            string letter = I.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void J_Click(object sender, RoutedEventArgs e)
        {
            J.IsEnabled = false;
            string letter = J.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void K_Click(object sender, RoutedEventArgs e)
        {
            K.IsEnabled = false;
            string letter = K.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
               
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void L_Click(object sender, RoutedEventArgs e)
        {
            L.IsEnabled = false;
            string letter = L.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
               
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void M_Click(object sender, RoutedEventArgs e)
        {
            M.IsEnabled = false;
            string letter = M.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
              
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void N_Click(object sender, RoutedEventArgs e)
        {
            N.IsEnabled = false;
            string letter = N.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }

                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void O_Click(object sender, RoutedEventArgs e)
        {
            O.IsEnabled = false;
            string letter = O.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void P_Click(object sender, RoutedEventArgs e)
        {
            P.IsEnabled = false;
            string letter = P.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
               
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void Q_Click(object sender, RoutedEventArgs e)
        {
            Q.IsEnabled = false;
            string letter = Q.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            R.IsEnabled = false;
            string letter = R.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void Z_Click(object sender, RoutedEventArgs e)
        {
            Z.IsEnabled = false;
            string letter = Z.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void Y_Click(object sender, RoutedEventArgs e)
        {
            Y.IsEnabled = false;
            string letter = Y.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
               
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {
            X.IsEnabled = false;
            string letter = X.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
               
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void W_Click(object sender, RoutedEventArgs e)
        {
            W.IsEnabled = false;
            string letter = W.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
               
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void V_Click(object sender, RoutedEventArgs e)
        {
            V.IsEnabled = false;
            string letter = V.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void U_Click(object sender, RoutedEventArgs e)
        {
            U.IsEnabled = false;
            string letter = U.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void T_Click(object sender, RoutedEventArgs e)
        {
            T.IsEnabled = false;
            string letter = T.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
                
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        private void S_Click(object sender, RoutedEventArgs e)
        {
            S.IsEnabled = false;
            string letter = S.Content.ToString().ToLower();
            if (word.ToLower().Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].ToString().ToLower() == letter)
                    {
                        labels[i].Content = letter;
                    }
                }
               
                foreach (Label Label in labels)
                {
                    if (Label.Content == "_")
                    { return; }
                }
                MessageBox.Show("You Won!!!");
            }
            else
            {
                wrongLetters++;
                SetButtonContentForWrongLetter();
                ChangeHangmanImage();
            }
            if (wrongLetters >= 6)
            {
                MessageBox.Show("You lost!!! The word was:" + word);
            }
        }

        public void SetButtonContentForWrongLetter()
        {
            if (ButtonWrong1.Content.ToString() == "")
            {
                ButtonWrong1.Content = "X";
            }
            else if (ButtonWrong2.Content.ToString() == "")
            {
                ButtonWrong2.Content = "X";
            }
            else if (ButtonWrong3.Content.ToString() == "")
            {
                ButtonWrong3.Content = "X";
            }
            else if (ButtonWrong4.Content.ToString() == "")
            {
                ButtonWrong4.Content = "X";
            }
            else if (ButtonWrong5.Content.ToString() == "")
            {
                ButtonWrong5.Content = "X";
            }
            else if (ButtonWrong6.Content.ToString() == "")
            {
                ButtonWrong6.Content = "X";
            }
        }
    }
}
