   M S B A M L   `   `   `  ����P  LRecrutingAssistantApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RecrutingAssistantAppRecrutingAssistantApp  5   	   -    'RecrutingAssistantApp.AddPositionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RecrutingAssistantApp     5   	     � Title$  Вакансии��5   	   $	��200��6   $	��295��6'    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��140 �6   �� 5      $	��140 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Имя вакансии��6   $
��Left=�6'   $��Center=�6C   $	��140��6^   $��0��6j   $��0��6z   �� 5   
   -   5        $��tbPositionName��5      $��0��6(   $��1��65   $	��120��6E   $��0,3,0,3q�6Q   $��Stretch=�6b   $��Stretch=�6�   �� 5   
   $��Открытость��6   $
��Left=�6%   $��Center=�6A   $	��140��6\   $��0��6h   $��1��6x   �� 5   
   -   5        $��tbIsOpen��5      $��1��6"   $��1��6/   $	��120��6?   $��0,3,0,3q�6K   $��Stretch=�6\   $��Stretch=�6z   �� 5   
   $��Зарплата��6   $
��Left=�6#   $��Center=�6?   $	��140��6Z   $��0��6f   $��2��6v   �� 5   
   -   5        $��tbSalary��5      $��2��6"   $��1��6/   $	��120��6?   $��0,3,0,3q�6K   $��Stretch=�6\   $��Stretch=�6z   �� 5   
   $��Работодатель��6   $
��Left=�6'   $��Center=�6C   $	��140��6^   $��0��6j   $��3��6z   �� 5   
   -   5        $��
cbEmployer��5      $��Stretch=�6%   $��Center=�6C   $	��120��6_   $��1��6k   $��3��6{    �� DisplayMemberPath$
 Name��6�   ��6�   �� 6�   �� 5   
   $�� ��6   $
��Left=�6   $��Center=�67   $	��140��6R   $��0��6^   $��4��6n   $��20��6{   �� 5   
   -   5        $��btnSave��5      $��Сохранить��6    $��Center=�64   $��Center=�6R   $	��120��6m   $��0��6y   $��5��6�   6�   �� 5    
   -   5        $��	btnCancel��5       $��Отмена��6"   $��Center=�63   $��Center=�6Q   $	��120��6l   $��1��6x   $��5��6�   6�   5!      5"      