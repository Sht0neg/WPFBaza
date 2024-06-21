﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls;

namespace kr
{
    public partial class MainWindow : Window
    {
        public bool isXTurn = true;
        public Button[,] buttons;

        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[,]
            {
                { Button0_0, Button0_1, Button0_2 },
                { Button1_0, Button1_1, Button1_2 },
                { Button2_0, Button2_1, Button2_2 }
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (button.Content != null) return;

            button.Content = isXTurn ? "X" : "O";
            isXTurn = !isXTurn;

            if (CheckWin())
            {
                MessageBox.Show($"{button.Content} победили!");
                ResetGame();
            }
            else if (IsDraw())
            {
                MessageBox.Show("Ничья!");
                ResetGame();
            }
        }

        private bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Content != null &&
                    buttons[i, 0].Content == buttons[i, 1].Content &&
                    buttons[i, 1].Content == buttons[i, 2].Content)
                {
                    return true;
                }

                if (buttons[0, i].Content != null &&
                    buttons[0, i].Content == buttons[1, i].Content &&
                    buttons[1, i].Content == buttons[2, i].Content)
                {
                    return true;
                }
            }

            if (buttons[0, 0].Content != null &&
                buttons[0, 0].Content == buttons[1, 1].Content &&
                buttons[1, 1].Content == buttons[2, 2].Content)
            {
                return true;
            }

            if (buttons[0, 2].Content != null &&
                buttons[0, 2].Content == buttons[1, 1].Content &&
                buttons[1, 1].Content == buttons[2, 0].Content)
            {
                return true;
            }

            return false;
        }

        private bool IsDraw()
        {
            foreach (Button button in buttons)
            {
                if (button.Content == null) return false;
            }
            return true;
        }

        private void ResetGame()
        {
            foreach (Button button in buttons)
            {
                button.Content = null;
            }
            isXTurn = true;
        }
    }
}