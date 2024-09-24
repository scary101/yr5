using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace yp5
{
    public partial class UserWindow : Window
    {
        private hsdEntitiess _context;

        public UserWindow()
        {
            InitializeComponent();
            _context = new hsdEntitiess();
            LoadUserData();
            LoadItems();
            LoadCategories();
        }

        // Метод для загрузки игроков
        private void LoadUserData()
        {
            CategoriesDataGrid.ItemsSource = _context.Players.ToList();
        }

        // Метод для загрузки предметов
        private void LoadItems()
        {
            ItemsDataGrid.ItemsSource = _context.Items.Select(i => new
            {
                i.ItemID,
                i.ItemName,
                CategoryName = i.ItemCategories.CategoryName,
                TypeName = i.ItemTypes.TypeName
            }).ToList();
        }

        // Метод для загрузки категорий
        private void LoadCategories()
        {
            CategoriesDataGrid.ItemsSource = _context.ItemCategories.ToList();
        }

        // Обработка выбора предмета
        private void ItemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ItemsDataGrid.SelectedItem as dynamic;
            if (selectedItem != null)
            {
                ItemNameTextBox.Text = selectedItem.ItemName;
                // Предположим, что ComboBox загружен списком категорий
                CategoryComboBox.SelectedValue = selectedItem.CategoryName;
            }
        }

        // Добавление нового предмета
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new Items
            {
                ItemName = ItemNameTextBox.Text,
                CategoryID = (int)CategoryComboBox.SelectedValue
            };

            _context.Items.Add(newItem);
            _context.SaveChanges();
            LoadItems();
        }

        // Обновление выбранного предмета
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ItemsDataGrid.SelectedItem as dynamic;
            if (selectedItem != null)
            {
                var itemToUpdate = _context.Items.Find(selectedItem.ItemID);
                if (itemToUpdate != null)
                {
                    itemToUpdate.ItemName = ItemNameTextBox.Text;
                    itemToUpdate.CategoryID = (int)CategoryComboBox.SelectedValue;
                    _context.SaveChanges();
                    LoadItems();
                }
            }
        }

        // Удаление выбранного предмета
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ItemsDataGrid.SelectedItem as dynamic;
            if (selectedItem != null)
            {
                var itemToDelete = _context.Items.Find(selectedItem.ItemID);
                if (itemToDelete != null)
                {
                    _context.Items.Remove(itemToDelete);
                    _context.SaveChanges();
                    LoadItems();
                }
            }
        }

        // Обработка выбора категории
        private void CategoriesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = CategoriesDataGrid.SelectedItem as ItemCategories;
            if (selectedCategory != null)
            {
                CategoryNameTextBox.Text = selectedCategory.CategoryName;
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
            LoadCategories();
        }

        // Обновление выбранной категории
        private void UpdateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = CategoriesDataGrid.SelectedItem as ItemCategories;
            if (selectedCategory != null)
            {
                var categoryToUpdate = _context.ItemCategories.Find(selectedCategory.CategoryID);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.CategoryName = CategoryNameTextBox.Text;
                    _context.SaveChanges();
                    LoadCategories();
                }
            }
        }

        // Удаление выбранной категории
        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = CategoriesDataGrid.SelectedItem as ItemCategories;
            if (selectedCategory != null)
            {
                var categoryToDelete = _context.ItemCategories.Find(selectedCategory.CategoryID);
                if (categoryToDelete != null)
                {
                    _context.ItemCategories.Remove(categoryToDelete);
                    _context.SaveChanges();
                    LoadCategories();
                }
            }
        }
    }
}
