   M S B A M L   `   `   `  ����>  :yp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:yp5yp5  5   	       yp5.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:yp5     5   	     � Title$  
UserWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� .@�5      �� $��Items��6   .��5      �� .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ ItemsDataGrid��5         AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *ItemID+6X     5      $
 Name��61    6?   �� *
ItemName+  5      $ Category��61    6C   �� *Category.CategoryName+5      �� 5       �� Orientation$ 
Horizontal=�6!   $��10q�6:   .+�5      �� -   5        	 ��Name$	 ItemNameTextBox��5   "   $	��200��6;   $��5q�6G   
 � ToolTip$
 	Item Name��6R   �� 5      -   5         ��Name$ CategoryComboBox��5   #   $	��150��6=   $��5q�6I   $
 Select Category��6T   �� 5      -   5        $	��Add��5   !   $��75��6/   $��5q�6:   6E   �� 5      -   5        $��Update��5   !   $��75��62   $��5q�6=   6H   �� 5      -   5        $��Delete��5   !   $��75��62   $��5q�6=   6H   5      5      5      �� 5      $��
Categories��6   .��5       �� .+�5!        -   5        $ CategoriesDataGrid��5!       .   .   5"        5#      $ ID��61    .  6=   �� *
CategoryID+6\     5$      $ Category Name��61    6H   �� *CategoryName+5&      �� 5(      $ 
Horizontal=�6!   $��10q�6:   .+�5)      �� -   5        $	 CategoryNameTextBox��5)   "   $	��200��6?   $��5q�6K   $
 Category Name��6V   �� 5*      -	   5        $	��Add��5*   !   $��75��6/   $��5q�6:   6E   �� 5+      -
   5        $��Update��5+   !   $��75��62   $��5q�6=   6H   �� 5,      -   5        $��Delete��5,   !   $��75��62   $��5q�6=   6H   5-      5.      5/      50      51      52      