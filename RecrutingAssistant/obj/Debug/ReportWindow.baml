   M S B A M L   `   `   `  ����m  iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting  5   	   P LRecrutingAssistantApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RecrutingAssistantAppRecrutingAssistantApp 5   	   (   "RecrutingAssistantApp.ReportWindow   5   	   twfmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RecrutingAssistantApp     5   	   -   5          � Title$$  Отчет по сделкам��5	   	   $	��450��6"   $	��800��6/    � 
ResizeMode$ NoResize=�6;    � WindowStartupLocation$ CenterScreen=�6Q   .��5
      � .+�5   
   	� -   5        $��	radioGist��5   B    	� 	GroupName$ 	GraphType��6   $��Гистограмма��6,   $��640,16,12,376q�6S    d� 	IsChecked$
 TrueY�6j   $
��Left=�6{   $��Center=�6�   	� 5   
   -   5        $��radioSpline��5   ?   $ 	GraphType��6   $��Линейный��6,   $��640,50,12,341q�6R   $
��Left=�6i   $��Center=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePicker1��5   Q   $��25��6   $
��Left=�6!   $��640,100,0,0q�6<   $	��Top=�6d   $	��115��6|     5   
   -   5        $��datePicker2��5   Q   $��25��6   $
��Left=�6!   $��640,130,0,0q�6<   $	��Top=�6d   $	��115��6|    J� RenderTransformOrigin$ 0.4,0&�6�   	� 5   
   -   5        $��radioDay��5   :   $ DateType��6   $��День��6+   $��640,164,12,232q�6J   $
��Left=�6b   $��Center=�6�   	� 5   
   -   5        $��
radioMonth��5   ;   $ DateType��6   $��
Месяц��6+   $��640,193,12,203q�6M   $
��Left=�6e   $��Center=�6�   	� 5   
   -   5        $��	radioYear��5   9   $ DateType��6   $��Год��6+   $��640,223,12,167q�6J   $
 TrueY�6b   $
��Left=�6s   $��Center=�6�   �� 5   
   -	   5        $��	btnAccept��5   /   $��Принять��6   $��23��6#   $��75��6@   $��LeftToRight=�6K   $��Right=�6   $��Bottom=�6�   $��	0,0,24,26q�6�   7  1System.Windows.Forms.Integration.WindowsFormsHost  5   
   $��0��6   $��0��6(   $��10,10,170,26q�68      Child. 5      ;   5System.Windows.Forms.DataVisualization.Charting.Chart  -
   5        	chart��5      5      5      5      