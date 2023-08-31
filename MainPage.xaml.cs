using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SolitareG00402138Repeat
{
    public class ButtonItem
    {
        public string Text { get; set; }
        public ICommand Command { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();

            // Set up the grid rows and columns
            for (int i = 0; i < 7; i++)
            {
                gameTable.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                gameTable.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            // Set row and column spacing
            gameTable.RowSpacing = 0;
            gameTable.ColumnSpacing = 0;

            // Initialize the game board
            InitializeBoard();
        }

        // 2D array to represent the game state
        int[,] playGame = new int[8, 8];

        // 2D array of buttons representing the game board
        Button[,] GameButton = new Button[8, 8];

        // Coordinates for tracking moves
        int startRow = 0, startCol = 0, finishRow = 0, finishCol = 0;

        private void InitializeBoard()
        {
            bool present;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    present = true;

                    // Check if the cell should have a marble
                    if (i < 2 || i >= 5)
                    {
                        if (j < 2 || j >= 5)
                        {
                            present = false;
                        }
                    }

                    int row = i;
                    int col = j;

                    if (present)
                    {
                        // Create a button for the marble
                        GameButton[i, j] = new Button
                        {
                            WidthRequest = 70,
                            HeightRequest = 70,
                            CornerRadius = 35,
                            BackgroundColor = Colors.White,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            ImageSource = ImageSource.FromFile("marble.png"),
                        };

                        // Set automation ID for testing or identification
                        GameButton[i, j].AutomationId = "btn" + row + col;

                        // Set initial game state and background
                        playGame[row, col] = 1;
                        if (row == 3 && col == 3)
                        {
                            GameButton[i, j].ImageSource = null;
                            GameButton[i, j].ImageSource = ImageSource.FromFile("background.jpg");
                            HeightRequest = 80;
                            WidthRequest = 80;
                            
                            playGame[row, col] = 0;
                        }

                        // Add button to the grid
                        gameTable.Children.Add(GameButton[i, j]);
                        gameTable.SetRow(GameButton[i, j], row);
                        gameTable.SetColumn(GameButton[i, j], col);

                        // event handler for button click
                        GameButton[i, j].Clicked += (sender, args) => Button_Clicked(sender, args);

                        DisplayAlert("Welcome to Solitare!");
                    }
                }
            }
        }

        private async void DisplayAlert(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Solitaire", message, "OK");
        }


        private void loadGame()
        {
            throw new NotImplementedException();
        }

        private void newGame()
        {
            bool present;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    present = true;

                    // Check if the cell should have a marble
                    if (i < 2 || i >= 5)
                    {
                        if (j < 2 || j >= 5)
                        {
                            present = false;
                        }
                    }

                    int row = i;
                    int col = j;

                    if (present)
                    {
                        // Create a button for the marble
                        GameButton[i, j] = new Button
                        {
                            WidthRequest = 70,
                            HeightRequest = 70,
                            CornerRadius = 35,
                            BackgroundColor = Colors.White,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            ImageSource = ImageSource.FromFile("marble.png"),
                        };

                        // Set automation ID for testing or identification
                        GameButton[i, j].AutomationId = "btn" + row + col;

                        // Set initial game state and background
                        playGame[row, col] = 1;
                        if (row == 3 && col == 3)
                        {
                            GameButton[i, j].ImageSource = null;
                            GameButton[i, j].ImageSource = ImageSource.FromFile("background.jpg");
                            HeightRequest = 80;
                            WidthRequest = 80;

                            playGame[row, col] = 0;
                        }

                        // Add button to the grid
                        gameTable.Children.Add(GameButton[i, j]);
                        gameTable.SetRow(GameButton[i, j], row);
                        gameTable.SetColumn(GameButton[i, j], col);

                        // event handler for button click
                        GameButton[i, j].Clicked += (sender, args) => Button_Clicked(sender, args);
                    }
                }
            }
                    }
                  

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string s = clickedButton.AutomationId;
            int rowPos = Convert.ToInt16(s.Substring(3, 1));
            int colPos = Convert.ToInt16(s.Substring(4, 1));
            Items.Add("Row = " + rowPos);
            Items.Add("Column = " + colPos);

            if (startRow == 0)
            {
                startRow = rowPos;
                startCol = colPos;
            }
            else
            {
                finishRow = rowPos;
                finishCol = colPos;
                checkMove(startRow, startCol, finishRow, finishCol);
                startRow = 0;
                startCol = 0;
            }
        }
        //reset button
        private void resetBtn(object sender, EventArgs e)
        {
            //7x7 grid
            bool present;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    present = true;
                    //checking if hole has marble between spot 2 and 5
                    if (i < 2 || i >= 5)
                    {
                        if (j < 2 || j >= 5)
                        {
                            present = false;
                        }
                    }
                    int row = i;
                    int col = j;

                    if (present == true)
                    {
                        GameButton[i, j] = new Button
                        {
                            WidthRequest = 70,
                            HeightRequest = 70,
                            CornerRadius = 35,
                            BackgroundColor = Colors.White,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            ImageSource = ImageSource.FromFile("marble.png"),
                        };
                        GameButton[i, j].AutomationId = "btn" + row + col;
                        playGame[row, col] = 1;
                        if (row == 3 && col == 3)
                        {
                            //set up game state and background Image
                            GameButton[i, j].ImageSource = null;
                            GameButton[i, j].ImageSource = ImageSource.FromFile("background.jpg");
                            playGame[row, col] = 0;
                        }
                        //add buttons to grid
                        gameTable.Children.Add(GameButton[i, j]);
                        gameTable.SetRow(GameButton[i, j], row);
                        gameTable.SetColumn(GameButton[i, j], col);
                        GameButton[i, j].Clicked += (sender, args) => Button_Clicked(sender, args);

                        removedMarblesCount = 0; // Reset the count of removed marbles
                        RemovedMarblesLabel.Text = $"Removed Marbles: {removedMarblesCount}";
                    }
                }
            }
        }
        //instructions menu display
        private void instructionsMenu(object sender, EventArgs e)
        {
            DisplayAlert("How to play","User clicks on a marble they want to move into the free space" +
                "when the user 'jumps' over a marble the marble gets removed and the aim of the game is to remove as many" +
                "marbles as possible before no more runs can be made.");
        }

        private async void DisplayAlert(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(title, message,"Ok");
        }

        private void saveGame(object sender, EventArgs e)
        {

        }

        private void checkMove(int startRow, int startCol, int finishRow, int finishCol)
        {
            //add information about each move
            Items.Add("Checking move from: ");
            Items.Add("Row=" + startRow + ", Col=" + startCol);
            Items.Add("\nto: ");
            Items.Add("\nRow=" + finishRow + ", Col=" + finishCol);

            if (startCol == finishCol)
            {
                // check if same collumn
                if (Math.Abs(startRow - finishRow) == 2)
                {
                    //calculate middle of board
                    int emptyHole = (startRow + finishRow) / 2;
                    if (playGame[startRow, startCol] == 1 && playGame[emptyHole, startCol] == 1 && playGame[finishRow, finishCol] == 0)
                    {
                        //move marble from start and place in new spot
                        playGame[startRow, startCol] = 0;
                        GameButton[startRow, startCol].ImageSource = ImageSource.FromFile("background.jpg");
                        playGame[emptyHole, startCol] = 0;
                        GameButton[emptyHole, startCol].ImageSource = ImageSource.FromFile("background.jpg");
                        playGame[finishRow, finishCol] = 1;
                        GameButton[finishRow, finishCol].ImageSource = ImageSource.FromFile("marble.png");
                    }
                }
            }

            if (startRow == finishRow)
            {
                //check if move is same row
                if (Math.Abs(startCol - finishCol) == 2)
                {
                    int emptyHole = (startCol + finishCol) / 2;
                    if (playGame[startRow, startCol] == 1 && playGame[startRow, emptyHole] == 1 && playGame[finishRow, finishCol] == 0)
                    {
                        playGame[startRow, startCol] = 0;
                        GameButton[startRow, startCol].ImageSource = ImageSource.FromFile("background.jpg");
                        playGame[startRow, emptyHole] = 0;
                        GameButton[startRow, emptyHole].ImageSource = ImageSource.FromFile("background.jpg");
                        playGame[finishRow, finishCol] = 1;
                        GameButton[finishRow, finishCol].ImageSource = ImageSource.FromFile("marble.png");

                        removedMarblesCount++;
                        RemovedMarblesLabel.Text = $"Removed Marbles: {removedMarblesCount}";
                    }
                }
            }

            Items.Add("\n");
        }


        //store information link: https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-7.0
        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();

        private int removedMarblesCount = 0;

        private void removedMarbles(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            //https://www.dofactory.com/code-examples/csharp/convert-string-to-int
            string s = clickedButton.AutomationId;
            int rowPos = Convert.ToInt16(s.Substring(3, 1));
            int colPos = Convert.ToInt16(s.Substring(4, 1));
            Items.Add("Row = " + rowPos);
            Items.Add("Column = " + colPos);

            if (startRow == 0)
            {
                //setting starting row and col
                startRow = rowPos;
                startCol = colPos;
            }
            else
            {
                //setting finishing row and col
                finishRow = rowPos;
                finishCol = colPos;
                checkMove(startRow, startCol, finishRow, finishCol);


                startRow = finishRow;
                startCol = finishCol;

                // Check if marbles were removed and update count

                //******************marbles dont always count for some moves *************************************
                if (playGame[startRow, startCol] == 1 && playGame[finishRow, finishCol] == 1)
                {
                    removedMarblesCount++;
                    RemovedMarblesLabel.Text = $"Removed Marbles: {removedMarblesCount}";
                 
                }
                //else
               // {
                   // MarblesLeft--;
                   // MarblesLeftLabel.text $"Marbles left: {MarblesLeft}";
               // }

               
            }

        }

    }

}
