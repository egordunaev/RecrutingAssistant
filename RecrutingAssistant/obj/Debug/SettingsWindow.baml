   M S B A M L   `   `   `  ����P  LRecrutingAssistantApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RecrutingAssistantAppRecrutingAssistantApp  5   	   *    $RecrutingAssistantApp.SettingsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RecrutingAssistantApp     5   	     � Title$/  )Настройки подключения��5   	   $��193.333��6'   $	��322��68    � 
ResizeMode$ NoResize=�6D    � WindowStartupLocation$ CenterScreen=�6Z   .��5	      � $��2q�6   $��Stretch=�6   $��Stretch=�64    � ColumnDefinitions 5
   
   �� 5      $	��150 �6   �� 5      $	��150 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Сервер��6   $��0��6"   $��0��6/   $��Stretch=�6?   $��Center=�6]   �� 5   
   $��База данных��6   $��1��6'   $��0��64   $��Stretch=�6D   $��Center=�6b   �� 5   
   $��Пользователь��6   $��2��6(   $��0��65   $��Stretch=�6E   $��Center=�6c   �� 5   
   $��Пароль��6   $��3��6"   $��0��6/   $��Stretch=�6?   $��Center=�6]   �� 5   
   $*��$Аутентификация Windows��6   $��4��62   $��0��6?   $	��145��6O   $��Stretch=�6\   $��Center=�6z   �� 5   
   -   5        $��tbServer��5      $��0��6"   $��1��6/   $��3q�6?   $	��135��6J   $��Stretch=�6V   �� 5   
   -   5        $��
tbDataBase��5      $��1��6$   $��1��61   $��3q�6A   $	��135��6L   $��Stretch=�6X   �� 5   
   -   5        $��tbUser��5      $��2��6    $��1��6-   $��3q�6=   $	��135��6H   $��Stretch=�6T   �� 5   
   -   5        $��
tbPassword��5      $��3��6$   $��1��61   $��3q�6A   $	��135��6L   $��Stretch=�6X   $��Center=�6v   �� 5   
   -   5        $��cbAuth��5      $��4��6!   $��1��6.   $��8,2,0,3q�6>   $
��Left=�6O   $��Center=�6j   6�   �� 5    
   -   5        $��btnSave��5       $��5��6    $��0��6-   $��Сохранить��6=   $��3q�6Q   $��25��6\   $	��135��6h   $��Stretch=�6t   6�   �� 5!   
   -   5        $��	btnCancel��5!      $��5��6"   $��1��6/   $��Отмена��6?   $��3q�6P   $��25��6[   $	��135��6g   $��Stretch=�6s   6�   5"      5#      