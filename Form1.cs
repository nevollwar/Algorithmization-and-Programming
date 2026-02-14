using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab2_variant5 
{
    public partial class Form1 : Form
    {
        // Глобальные переменные
        int startRange = 0;
        int endRange = 0;
        int currentSingle = -1;
        public Form1()
        {
            InitializeComponent();

            // Настройка фильтра при запуске
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Все числа");
            cmbFilter.Items.Add("Простые");
            cmbFilter.Items.Add("Совершенные");
            cmbFilter.Items.Add("Палиндромы");
            cmbFilter.Items.Add("Армстронга");
            cmbFilter.SelectedIndex = 0; // Выбираем первый пункт
        }

        // Математические методы
        public static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }

        public static bool IsPerfect(int n)
        {
            if (n < 6) return false;
            int sum = 1;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                    if (i != n / i) sum += n / i;
                }
            }
            return sum == n;
        }

        public static bool IsPalindrome(int n)
        {
            string s = n.ToString();
            return s == new string(s.Reverse().ToArray());
        }

        public static bool IsArmstrong(int n)
        {
            string s = n.ToString();
            long sum = 0;
            foreach (char c in s)
                sum += (long)Math.Pow(int.Parse(c.ToString()), s.Length);
            return sum == n;
        }

        // Кнопка старт
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            // 1. Анализ одиночного числа
            if (!string.IsNullOrEmpty(txtSnglNum.Text))
            {
                if (int.TryParse(txtSnglNum.Text, out int s)) currentSingle = s;
                else MessageBox.Show("В верхнем поле не число!");
            }
            else currentSingle = -1;

            // 2. Анализ диапазона
            bool hasRange = false;
            if (!string.IsNullOrEmpty(txtStart.Text) && !string.IsNullOrEmpty(txtEnd.Text))
            {
                if (int.TryParse(txtStart.Text, out startRange) && int.TryParse(txtEnd.Text, out endRange))
                {
                    if (startRange > endRange) { int t = startRange; startRange = endRange; endRange = t; }
                    hasRange = true;
                }
                else MessageBox.Show("В полях диапазона ошибка!");
            }
            else
            {
                // Если поля пустые
                startRange = 0;
                endRange = -1;
                // Очищаем график, если диапазон удалили
                if (pictureBox1.Image != null)
                {
                    using (Graphics g = Graphics.FromImage(pictureBox1.Image)) { g.Clear(Color.White); }
                    pictureBox1.Invalidate();
                }
            }

            // 3. Вызываем обновление
            if (hasRange) DrawGraph();
            UpdateList();
        }

        // Рисование графика
        private void DrawGraph()
        {
            // 1. Считаем, сколько чисел надо нарисовать
            int count = endRange - startRange + 1;

            // Защита от вылета
            // Windows не умеет рисовать картинки длиннее 65 000 пикселей.
            // Если чисел больше 1500, мы рисуем только первые 1500, иначе программа сломается.
            if (count > 1500)
            {
                MessageBox.Show($"Диапазон слишком большой ({count} чисел)!\n" +
                                "График покажет только первые 1500 чисел.\n" +
                                "Для остальных введите новый диапазон.",
                                "Ограничение графика", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                count = 1500; // Принудительно ограничиваем
            }

            int step = 40; // Ширина одного столбика
            int width = Math.Max(panel1.Width, count * step + 50);
            int height = panel1.Height - 20;

            // Настраиваем размер области рисования
            pictureBox1.Width = width;
            pictureBox1.Height = height;

            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                int x = 20; // Отступ слева

                // Рисуем только то количество, которое влезает (count)
                for (int i = 0; i < count; i++)
                {
                    int n = startRange + i; // Текущее число

                    // Линия
                    g.DrawLine(Pens.LightGray, x, height - 20, x, 20);
                    // Подпись
                    g.DrawString(n.ToString(), this.Font, Brushes.Black, x - 10, height - 15);

                    // Значки 
                    if (IsPrime(n)) g.FillEllipse(Brushes.Red, x - 4, height - 30, 8, 8); // Красный (Низ)
                    if (IsPalindrome(n)) g.FillRectangle(Brushes.Blue, x - 4, height / 2, 8, 8); // Синий (Центр)
                    if (IsArmstrong(n)) g.FillEllipse(Brushes.Green, x - 4, 30, 8, 8); // Зеленый (Верх)
                    if (IsPerfect(n)) g.DrawLine(new Pen(Color.Gold, 3), x, height - 20, x, 20); // Золото

                    x += step;
                }
            }
            pictureBox1.Image = bmp;
        }

        // Обновление списка по фильтру
        private void UpdateList()
        {
            lstResults.Items.Clear(); // Очищаем старое
            string filter = cmbFilter.Text;

            // Сначала всегда показываем одиночное число, если оно есть 
            if (currentSingle >= 0)
            {
                string res = $"Анализ числа {currentSingle}: ";
                if (IsPrime(currentSingle)) res += "Простое; ";
                if (IsPerfect(currentSingle)) res += "СОВЕРШЕННОЕ! ";
                if (IsPalindrome(currentSingle)) res += "Палиндром; ";
                if (IsArmstrong(currentSingle)) res += "Армстронга; ";

                lstResults.Items.Add(res);
                lstResults.Items.Add("");
            }

            // Добавляем числа из диапазона с учетом фильтра
            for (int n = startRange; n <= endRange; n++)
            {
                bool show = false;
                if (filter == "Все числа") show = true;
                else if (filter == "Простые" && IsPrime(n)) show = true;
                else if (filter == "Совершенные" && IsPerfect(n)) show = true;
                else if (filter == "Палиндромы" && IsPalindrome(n)) show = true;
                else if (filter == "Армстронга" && IsArmstrong(n)) show = true;

                if (show)
                {
                    string info = $"{n}";
                    if (IsPrime(n)) info += " (Прост)";
                    if (IsPerfect(n)) info += " (Соверш)";
                    if (IsPalindrome(n)) info += " (Палиндром)";
                    if (IsArmstrong(n)) info += " (Армстронг)";
                    lstResults.Items.Add(info);
                }
            }
        }

        // Список
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (endRange > 0) UpdateList();
        }

        // Справка
        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpText =
                "Инструкция\n" +
                "1. Введите числа в поля 'ОТ' и 'ДО' (например, 1 и 500).\n" +
                "2. Нажмите 'Старт'.\n" +
                "3. В списке сверху можно выбирать фильтр (только простые и т.д.).\n\n" +

                "Обозначения на графике:\n" +
                "Красная точка (снизу) — Простое число\n" +
                "Синий квадрат (центр) — Палиндром (читается одинаково: 121)\n" +
                "Зеленый круг (сверху) — Число Армстронга (сумма цифр в степени)\n" +
                "Золотая линия (весь столб) — Совершенное число\n\n" +

                "ВАЖНО: Из-за ограничений Windows, график вмещает около 1500 чисел за раз.";

            MessageBox.Show(helpText, "Справка и Легенда", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRunTests_Click(object sender, EventArgs e)
        {
            // Очищаем список для отчета
            lstResults.Items.Clear();
            lstResults.Items.Add("ЗАПУСК МОДУЛЬНЫХ ТЕСТОВ");
            int passed = 0;
            int failed = 0;

            // Функция-помощник для проверки (аналог Assert)
            Action<string, bool> AssertTest = (name, condition) => {
                if (condition)
                {
                    lstResults.Items.Add($"[OK] {name}");
                    passed++;
                }
                else
                {
                    lstResults.Items.Add($"[FAIL] {name} !!!");
                    failed++;
                }
            };

            try
            {
                // 1. Тестируем IsPrime
                AssertTest("IsPrime(7) == True", IsPrime(7) == true);
                AssertTest("IsPrime(10) == False", IsPrime(10) == false);

                // 2. Тестируем IsPerfect
                AssertTest("IsPerfect(6) == True", IsPerfect(6) == true);
                AssertTest("IsPerfect(28) == True", IsPerfect(28) == true);
                AssertTest("IsPerfect(10) == False", IsPerfect(10) == false);

                // 3. Тестируем IsPalindrome
                AssertTest("IsPalindrome(121) == True", IsPalindrome(121) == true);
                AssertTest("IsPalindrome(123) == False", IsPalindrome(123) == false);

                // 4. Тестируем IsArmstrong
                AssertTest("IsArmstrong(153) == True", IsArmstrong(153) == true);
                AssertTest("IsArmstrong(100) == False", IsArmstrong(100) == false);

                lstResults.Items.Add("");
                lstResults.Items.Add($"ИТОГО: Пройдено: {passed}, Ошибок: {failed}");

                if (failed == 0) MessageBox.Show("Все тесты пройдены успешно!", "Unit Testing OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Обнаружены ошибки в тестах!", "Unit Testing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении тестов: " + ex.Message);
            }
        }
    }
}