   M S B A M L   `   `   `  ����P  LRecrutingAssistantApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RecrutingAssistantAppRecrutingAssistantApp  5   	   -    'RecrutingAssistantApp.AddEmployerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RecrutingAssistantApp     5   	     � Title$  Работодатели��5   	   $	��200��6   $	��305��6+    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��140 �6   �� 5      $	��160 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $%��Имя работодателя��6   $
��Left=�6+   $��Center=�6G   $	��140��6b   $��0��6n   $��0��6~   �� 5   
   -   5        $��tbName��5      $��0��6    $��1��6-   $	��132��6=   $��0,3,0,3q�6I   $��Center=�6Z   $��Stretch=�6w   �� 5   
   $��
Адрес��6   $
��Left=�6    $��Center=�6<   $	��140��6W   $��0��6c   $��1��6s   �� 5   
   -   5        $��	tbAddress��5      $��1��6#   $��1��60   $	��132��6@   $��0,3,0,3q�6L   $��Stretch=�6]   $��Stretch=�6{   �� 5   
   $!��Номер телефона��6   $
��Left=�6)   $��Center=�6E   $	��140��6`   $��0��6l   $��2��6|   �� 5   
   -   5        $��tbPhoneNumber��5      $��2��6'   $��1��64   $	��132��6D   $��0,3,0,3q�6P   $��Stretch=�6a   $��Stretch=�6   �� 5   
   $��Тип работы��6   $
��Left=�6%   $��Center=�6A   $	��140��6\   $��0��6h   $��3��6x   �� 5   
   -   5        $��cbTypeOfWork��5      $��Stretch=�6'   $��Center=�6E   $	��132��6a   $��1��6m   $��3��6}    �� DisplayMemberPath$
 Name��6�   ��6�   �� 6�   �� 5   
   $�� ��6   $
��Left=�6   $��Center=�67   $	��140��6R   $��0��6^   $��4��6n   $��20��6{   �� 5   
   -   5        $��btnSave��5      $��Сохранить��6    $��Center=�64   $��Center=�6R   $	��120��6m   $��0��6y   $��5��6�   6�   �� 5    
   -   5        $��	btnCancel��5       $��Отмена��6"   $��Center=�63   $��Center=�6Q   $	��120��6l   $��1��6x   $��5��6�   6�   5!      5"      