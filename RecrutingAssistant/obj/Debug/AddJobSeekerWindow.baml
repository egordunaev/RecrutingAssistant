   M S B A M L   `   `   `  ����P  LRecrutingAssistantApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RecrutingAssistantAppRecrutingAssistantApp  5   	   .    (RecrutingAssistantApp.AddJobSeekerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RecrutingAssistantApp     5   	     � Title$  Соискатель��5   	   $	��280��6   $	��365��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��170 �6   �� 5      $	��180 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Имя��6   $
��Left=�6   $��Center=�6:   $	��180��6U   $��0��6a   $��0��6q   �� 5   
   -   5        $��tbFirstName��5      $��0��6%   $��1��62   $	��165��6B   $��0,3,0,3q�6N   $��Stretch=�6_   $��Stretch=�6}   �� 5   
   $��Фамилия��6   $
��Left=�6"   $��Center=�6>   $	��180��6Y   $��0��6e   $��1��6u   �� 5   
   -   5        $��tbSecondName��5      $��1��6&   $��1��63   $	��165��6C   $��0,3,0,3q�6O   $��Stretch=�6`   $��Stretch=�6~   �� 5   
   $��Отчество��6   $
��Left=�6#   $��Center=�6?   $	��180��6Z   $��0��6f   $��2��6v   �� 5   
   -   5        $��tbThirdName��5      $��2��6%   $��1��62   $	��165��6B   $��0,3,0,3q�6N   $��Stretch=�6_   $��Stretch=�6}   �� 5   
   $��Квалификация��6   $
��Left=�6'   $��Center=�6C   $	��180��6^   $��0��6j   $��3��6z   �� 5    
   -   5        $��tbQualification��5       $��3��6)   $��1��66   $	��165��6F   $��0,3,0,3q�6R   $��Stretch=�6c   $��Stretch=�6�   �� 5!   
   $3��-Предполагаемая зарплата��6   $
��Left=�62   $��Center=�6N   $	��180��6i   $��0��6u   $��4��6�   �� 5"   
   -   5        $��tbAssumedSalary��5"      $��4��6)   $��1��66   $	��165��6F   $��0,3,0,3q�6R   $��Stretch=�6c   $��Stretch=�6�   �� 5#   
   $'��!Прочая информация��6   $
��Left=�6,   $��Center=�6H   $	��180��6c   $��0��6o   $��5��6   �� 5$   
   -   5        $��tbMisc��5$      $��5��6    $��1��6-   $	��165��6=   $��0,3,0,3q�6I   $��Stretch=�6Z   $��Stretch=�6x   �� 5%   
   $��Тип работы��6   $
��Left=�6%   $��Center=�6A   $	��180��6\   $��0��6h   $��6��6x   �� 5&   
   -   5        $��cbTypeOfWork��5&      $��Stretch=�6'   $��Center=�6E   $	��165��6a   $��1��6m   $��6��6}    �� DisplayMemberPath$
 Name��6�   ��6�   �� 6�   �� 5'   
   $�� ��6   $
��Left=�6   $��Center=�67   $	��180��6R   $��0��6^   $��7��6n   $��20��6{   �� 5(   
   -   5        $��btnSave��5(      $��Сохранить��6    $��Center=�64   $��Center=�6R   $	��120��6m   $��0��6y   $��8��6�   6�   �� 5)   
   -	   5        $��	btnCancel��5)      $��Отмена��6"   $��Center=�63   $��Center=�6Q   $	��120��6l   $��1��6x   $��8��6�   6�   5*      5+      