using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace yp5
{
    public partial class AdminWindow : Window
    {
        private readonly hsdEntitiess _context;

        public AdminWindow()
        {
            InitializeComponent();
            _context = new hsdEntitiess();  // Инициализация контекста базы данных
            LoadItems();  // Загрузка данных
            LoadCategories();  // Загрузка категорий
        }

        // Загрузка предметов
        private void LoadItems()
        {
            ItemsDataGrid.ItemsSource = _context.Items.ToList();  // Заполнение таблицы предметов
        }

        // Загрузка категорий
        private void LoadCategories()
        {
            CategoriesDataGrid.ItemsSource = _context.ItemCategories.ToList();  // Заполнение таблицы категорий

            // Заполнение ComboBox категориями
            CategoryComboBox.ItemsSource = _context.ItemCategories.ToList();
            CategoryComboBox.DisplayMemberPath = "CategoryName";  // Отображаемое поле
            CategoryComboBox.SelectedValuePath = "CategoryID";  // Привязка ID категории
        }

        // Добавление нового предмета
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new Items
            {
                ItemName = ItemNameTextBox.Text,
                CategoryID = (int)CategoryComboBox.SelectedValue // Привязка категории
            };

            _context.Items.Add(newItem);
            _context.SaveChanges();  // Сохранение в БД
            LoadItems();  // Перезагрузка данных
        }

        // Обновление выбранного предмета
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is Items selectedItem)
            {
                selectedItem.ItemName = ItemNameTextBox.Text;
                selectedItem.CategoryID = (int)CategoryComboBox.SelectedValue;

                _context.SaveChanges();  // Сохранение изменений
                LoadItems();  // Перезагрузка данных
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для обновления.");
            }
        }

        // Удаление выбранного предмета
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is Items selectedItem)
            {
                _context.Items.Remove(selectedItem);
                _context.SaveChanges();  // Сохранение изменений
                LoadItems();  // Перезагрузка данных
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.");
            }
        }

        // Добавление новой категории
        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var newCategory = new ItemCategories
            {
                CategoryName = CategoryNameTextBox.Text
            };

            _context.ItemCategories.Add(newCategory);
            _context.SaveChanges();
            LoadCategories();  // Перезагрузка категорий
        }

        // Обновление выбранной категории
        private void UpdateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is ItemCategories selectedCategory)
            {
                selectedCategory.CategoryName = CategoryNameTextBox.Text;
                _context.SaveChanges();
                LoadCategories();  // Перезагрузка категорий
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите категорию для обновления.");
            }
        }

        // Удаление выбранной категории
        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is ItemCategories selectedCategory)
            {
                _context.ItemCategories.Remove(selectedCategory);
                _context.SaveChanges();
                LoadCategories();  // Перезагрузка категорий
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите категорию для удаления.");
            }
        }

        // Обработка выбора предмета в таблице
        private void ItemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is Items selectedItem)
            {
                ItemNameTextBox.Text = selectedItem.ItemName;
                CategoryComboBox.SelectedValue = selectedItem.CategoryID;  // Привязка категории
            }
        }

        // Обработка выбора категории в таблице
        private void CategoriesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is ItemCategories selectedCategory)
            {
                CategoryNameTextBox.Text = selectedCategory.CategoryName;
            }
        }
    }
}
