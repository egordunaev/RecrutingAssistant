   M S B A M L   `   `   `  ����P  LRecrutingAssistantApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RecrutingAssistantAppRecrutingAssistantApp  5   	   )    #RecrutingAssistantApp.AddDealWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RecrutingAssistantApp     5   	     � Title$  Сделки��5   	   $	��200��6   $	��293��6%    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�6G   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��140 �6   �� 5      $	��140 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Соискатель��6   $
��Left=�6%   $��Center=�6A   $	��100��6\   $��0��6h   $��0��6x   �� 5   
   -   5        $��cbSeeker��5      $��Center=�6#   $��Center=�6@   $	��120��6\   $��1��6h   $��0��6x    �� DisplayMemberPath$ FullName��6�   ��6�   �� 6�   �� 5   
   $��Вакансия��6   $
��Left=�6#   $��0��6>   $��1��6N   $	��100��6[   $��Center=�6g   �� 5   
   -   5        $��
cbPosition��5      $��Center=�6%   $��Center=�6B   $	��120��6^   $��1��6j   $��1��6z   $ FullPosition��6�   ��6�   �� 6�   �� 5   
   $��Дата сделки��6   $
��Left=�6&   $��0��6A   $��2��6Q   $	��100��6^   $��Center=�6j   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDateOfDeal��5      $��2��6)   $��2��69   $��Center=�6F   $	��120��6c   $��Center=�6o   �� 5   
   $��Комиссионные��6   $
��Left=�6'   $��0��6B   $��3��6R   $	��100��6_   $��Center=�6k   �� 5   
   -   5        $��tbCommissions��5      $��3��6'   $��1��64   $	��120��6D   $��20��6P   $��Center=�6\   $��Center=�6y   �� 5   
   $�� ��6   $
��Left=�6   $��0��66   $��4��6F   $��Center=�6S   $��20��6n   �� 5   
   -   5        $��btnSave��5      $��Сохранить��6    $��Center=�64   $��Center=�6R   $	��120��6m   $��0��6y   $��5��6�   6�   �� 5    
   -   5        $��	btnCancel��5       $��Отмена��6"   $��Center=�63   $��Center=�6Q   $	��120��6l   $��1��6x   $��5��6�   6�   5!      5"      