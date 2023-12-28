using System.Windows;
using System.Windows.Controls;

namespace TestSystem_v3._0
{
    /// <summary>
    /// Логика взаимодействия для UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        int userId;
        int themeId;
        // определение спискка вопросов и статистики
        List<Question> questionList;
        List<ScoreTable> scoreTableList;
        List<Theme> themeList;
        List<Question> Test;

        // определениеформ для проведения тестирования
        ListBox ThemeListBox;
        RadioButton UserAnsver1True;
        RadioButton UserAnsver2True;
        RadioButton UserAnsver3True;
        RadioButton UserAnsver4True;
        Grid UserTestGrid = new Grid
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 40, 0, 0)
        };

        int askNumber, scoreTest;
        int countQuestions = 10; //количество вопросв в тесте

        public UserForm(int id)
        {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())  { themeList = db.Themes.Where(t => t.IsHidden == false).ToList(); }

            userId = id;
            MenuUser();
        }

        private void MenuUser()
        {
            UserMainGrid.Children.Clear();
            Menu UserMenu = new Menu
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 26,
                Width = 790,
                Margin = new Thickness(0, 1, 0, 0),
            };
            var menuItem1 = new MenuItem { Header = "Тесты" };
            var menuItem2 = new MenuItem { Header = "Статистика" };
            var menuItem3 = new MenuItem { Header = "Справка" };
            var menuItem4 = new MenuItem { Header = "Выход" };
            menuItem1.Click += MenuItemTest_Click;
            menuItem2.Click += MenuItemSatistics_Click;
            menuItem3.Click += MenuItemManual_Click;
            menuItem4.Click += MenuItemExit_Click;
            UserMenu.Items.Add(menuItem1);
            UserMenu.Items.Add(menuItem2);
            UserMenu.Items.Add(menuItem3);
            UserMenu.Items.Add(menuItem4);
            UserMainGrid.Children.Add(UserMenu);
        }

        private void MenuItemTest_Click(object sender, RoutedEventArgs e) 
        {
            UserMainGrid.Children.Clear();
            MenuUser();
            ThemeListBox = new ListBox
            {
                Margin = new Thickness(0, 70, 500, 0),
                Width = 280,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            foreach (var theme in themeList)
            {
                string themeView = $"{theme.Id}. - {theme.ThemeName}";
                ThemeListBox.Items.Add(themeView);
            }
            Label ThemeListLabel = new Label { Content = "Выберите тему тестирования:", Margin = new Thickness(0, 40, 0, 0) };
            Button buttonChooseTheme = new Button
            {
                Content = "Начать тестирование",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 34,
                Width = 230,
                Margin = new Thickness(300, 100, 0, 0)
            };

            buttonChooseTheme.Click += buttonChooseThemeClick;
            UserMainGrid.Children.Add(ThemeListLabel);
            UserMainGrid.Children.Add(ThemeListBox);
            UserMainGrid.Children.Add(buttonChooseTheme);
        }

        private void buttonChooseThemeClick(object sender, RoutedEventArgs e)
        {
            if (ThemeListBox.SelectedItems.Count == 0) { MessageBox.Show("Выберите тему для тестирования."); }
            else
            {
                int themeDot = ThemeListBox.SelectedItem.ToString().IndexOf('.');
                themeId = Int32.Parse(ThemeListBox.SelectedItem.ToString().Substring(0,themeDot));
                using (ApplicationContext db = new ApplicationContext()) { questionList = db.Questions.Where(x => x.themeId == themeId).ToList(); }
                if (questionList.Count < countQuestions) { MessageBox.Show("В базе вопросов меньше чем надо для проведения тестирования. Обратитесь к администратору."); }
                else
                {
                    UserMainGrid.Children.Clear();
                    MenuUser();
                    Test = new List<Question>();
                    Random r = new Random();
                    int k = 0, temp;
                    while (k <countQuestions) //сборка 10 неповторяющихя случайных вопросов из существующего списка вопросов
                    {
                        temp = r.Next(questionList.Count);
                        bool check = true;
                        for (int i =0; i< k; i++) 
                        {
                            if (Test[i].Id == questionList[temp].Id) 
                            { check = false; }
                        }
                        if (check) 
                        {
                            Test.Add(questionList[temp]);
                            k++;
                        }
                    }
                    askNumber = 0;
                    scoreTest = 0;
                    ShowNextAsk(sender, e);
                }
            }
        }

        private void ShowNextAsk(object sender, RoutedEventArgs e)
        {
            Button ButtonNextQuestion;
            Button ButtonCancelPassTest;
            UserMainGrid.Children.Clear();
            UserTestGrid.Children.Clear();
            TextBlock textAsk = new TextBlock { Text = $"Вопрос {askNumber + 1}-й: {Test[askNumber].Ask}" ,
            TextWrapping = TextWrapping.Wrap,
            };
            Label UserQuestionText = new Label
            {
                Content = textAsk,
                Margin = new Thickness(0, 0, 0, 0)
            };
            Label UserAnsver1Text = new Label
            {
                Content = Test[askNumber].Answer1,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(120, 60, 0, 0)
            };
            Label UserAnsver2Text = new Label
            {
                Content = Test[askNumber].Answer2,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(120, 80, 0, 0)
            };
            Label UserAnsver3Text = new Label
            {
                Content = Test[askNumber].Answer3,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(120, 100, 0, 0)
            };
            Label UserAnsver4Text = new Label
            {
                Content = Test[askNumber].Answer4,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(120, 120, 0, 0)
            };
            UserAnsver1True = new RadioButton
            {
                GroupName = "true",
                IsChecked = false,
                Margin = new Thickness(0, 60, 0, 0),
            };
            UserAnsver2True = new RadioButton
            {
                GroupName = "true",
                IsChecked = false,
                Margin = new Thickness(0, 80, 0, 0),
            };
            UserAnsver3True = new RadioButton
            {
                GroupName = "true",
                IsChecked = false,
                Margin = new Thickness(0, 100, 0, 0),
            };
            UserAnsver4True = new RadioButton
            {
                GroupName = "true",
                IsChecked = false,
                Margin = new Thickness(0, 120, 0, 0),
            };
            string NextButtonText = askNumber < countQuestions - 1 ? "Следующий вопрос" : "Завершить тест";
            ButtonNextQuestion = new Button
            {
                Content = NextButtonText,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 160, 0, 0)
            };
            ButtonCancelPassTest = new Button
            {
                Content = "Прервать тестирование",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(120, 160, 0, 0)
            };
            ButtonNextQuestion.Click += NextQuestionClick;
            ButtonCancelPassTest.Click += CancelPassTestClick;

            UserTestGrid.Children.Add(UserQuestionText);
            UserTestGrid.Children.Add(UserAnsver1Text);
            UserTestGrid.Children.Add(UserAnsver2Text);
            UserTestGrid.Children.Add(UserAnsver3Text);
            UserTestGrid.Children.Add(UserAnsver4Text);
            UserTestGrid.Children.Add(UserAnsver1True);
            UserTestGrid.Children.Add(UserAnsver2True);
            UserTestGrid.Children.Add(UserAnsver3True);
            UserTestGrid.Children.Add(UserAnsver4True);
            UserTestGrid.Children.Add(ButtonNextQuestion);
            UserTestGrid.Children.Add(ButtonCancelPassTest);

            UserMainGrid.Children.Add(UserTestGrid);
        }

        private void NextQuestionClick(object sender, RoutedEventArgs e)
        {
            if (UserAnsver1True.IsChecked == false &&
                UserAnsver2True.IsChecked == false &&
                UserAnsver3True.IsChecked == false &&
                UserAnsver4True.IsChecked == false) MessageBox.Show("Надо выбрать хотя бы один ответ");
            else
            {                
                if (UserAnsver1True.IsChecked == true && Test[askNumber].rightAnswer == 1) scoreTest++;
                else if (UserAnsver2True.IsChecked == true && Test[askNumber].rightAnswer == 2) scoreTest++;
                else if (UserAnsver3True.IsChecked == true && Test[askNumber].rightAnswer == 3) scoreTest++;
                else if (UserAnsver4True.IsChecked == true && Test[askNumber].rightAnswer == 4) scoreTest++;
                if (askNumber < countQuestions - 1)
                {
                    askNumber++;
                    ShowNextAsk(sender, e);
                }
                else
                {                    
                    MessageBox.Show($"Балл за прохождение теста {scoreTest}");
                    
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        //scoreTableList.Add(new ScoreTable { UserId = userId, ThemeId = themeId, Score = scoreTest });
                        ScoreTable checkTheme = null;
                        try
                        {
                            checkTheme = db.ScoreTables.Where(u => u.UserId == userId && u.ThemeId == themeId).Single();
                        }
                        catch { }
                        finally { }
                        if (checkTheme == null) 
                        {
                            ScoreTable tempScore = new ScoreTable { UserId = userId, ThemeId = themeId, Score = scoreTest };
                            db.ScoreTables.Add(tempScore); 
                        }
                        else { checkTheme.Score = scoreTest; }
                        db.SaveChanges();
                    }
                    MenuUser();
                }

            }
        }

        private void CancelPassTestClick(object sender, RoutedEventArgs e) { MenuUser(); }

        private void MenuItemSatistics_Click(object sender, RoutedEventArgs e)
        {
            UserMainGrid.Children.Clear();
            MenuUser();
            using (ApplicationContext db = new ApplicationContext())
            {
                scoreTableList = db.ScoreTables.Where(u =>u.UserId ==  userId).ToList();
                themeList = db.Themes.ToList();
            }
            ThemeListBox = new ListBox
            {
                Margin = new Thickness(0, 40, 0, 0),
                Width = 280,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            ThemeListBox.Items.Add("Ваши пройденные тесты:");
            for (int i = 0; i < scoreTableList.Count; i++)
            {

                string nameTheme = themeList.Where(t => t.Id == scoreTableList[i].ThemeId).Single().ThemeName;
                ThemeListBox.Items.Add($" Тема {nameTheme} - оценка {scoreTableList[i].Score}");
            }
            UserMainGrid.Children.Add(ThemeListBox);
        }

        private void MenuItemManual_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                string helpText = db.Helps.Where(h => h.Id == 2).Single().Text;
                MessageBox.Show(helpText);
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
