   M S B A M L   `   `   `  ����  GymStaffDataBaseApp'    !GymStaffDataBaseApp.Output_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Output Data Grid��5   	   $	��304��6"   $	��629��6/   $	��304��6;   $	��629��6K    � WindowStartupLocation$ CenterScreen=�6Z   .��5      � -   5        $��Output_Grid��5       � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5
   
   �� -   5        $��Filter_ComboBox��5
      $
��Left=�6*   $��	94,0,0,16q�6E   $��Bottom=�6X   $	��286��6s   $��Arial)�6   $��22��6�   $��7��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	Data_Grid��5       �� IsTextSearchEnabled .    CanUserReorderColumns .     CanUserResizeColumns .     
IsReadOnly . $��1��6�   $��0,0,0,55q�6�   �� 5   
   -   5        $��Filter_Label��5      $��Фильтр��6$   $
��Left=�65   $��Bottom=�6P   $��	19,0,0,10q�6k   $��70��6~   $��Arial)�6�   $��16(�6�   $��30��6�   �� 5   
   -   5        $ ��Second_Name_Filter_TextBox��5      $
��Left=�64   $��
385,0,0,10q�6O   $��Bottom=�6c   $	��214��6~   $��30��6�   $��Arial)�6�   $��16(�6�   $��2��6�   6�   5      5      