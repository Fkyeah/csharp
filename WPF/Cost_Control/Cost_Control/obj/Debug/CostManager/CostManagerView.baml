   M S B A M L   `   `   `  ����G  CCost_Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Cost_Control.CostManagerCost_Control.CostManager  5      .    (Cost_Control.CostManager.CostManagerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      /vm&clr-namespace:Cost_Control.CostManager  5        � DataContext  5
      3  -Cost_Control.CostManager.CostManagerViewModel  5   
   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closing��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *WindowClosing+5      .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      � $��0��6    � RowDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�5      .+�5      �� -   5         ��Name$ cbCurrentUser��5      $
��Left=�5       $	��Top=�5!      $	��140��5"      $��	25 25 0 0q�5#      ��5$      �� *Users+	 �� SelectedItem	 5%      �� *SelectedName+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 5&        5'      $ SelectionChanged��6-   . 5(   "      68   �� *CurrentUserChangedCommand+5)      5+      &   System.Windows.Controls.Calendar  5,      -   5          Name$ Calendar��5,      $��0��5-      $��Right=�5.      $	��Top=�5/      $	��165��50      $��	25 22 0 0q�51         SelectedDate 52      �� *SelectedDate+$
 TwoWay=�$ PropertyChanged=� 53        54      $ SelectedDatesChanged��6-   . 55   "      68   �� *DateChangedCommand+56      58      59      �� 5:      $��1��6   .+�5;      �� $$��На что потрачено��6    $��1��5<       $��25 0 0 0q�5=       $��15(�5>       �� 5?      -   5         ��Name$ 
tbCostName��5?      $��1��5@      $	��250��5A      $��35��5B      $��15(�5C      $	��Top=�5D      $
��Left=�5E      $��Center=�5F      $��25 5 0 0q�5G      ��5H      �� *
CostName+$
 TwoWay=�$ PropertyChanged=�.��6j   5I      �� 5J      $��
Сумма��6    $��1��5K       $��25 5 0 0q�5L       $��15(�5M       �� 5N      -   5        $ tbSum��5N      $��1��5O      $	��250��5P      $��35��5Q      $��15(�5R      $��Center=�5S      $
��Left=�5T      $��Center=�5U      $��	25 5 0 20q�5V      ��5W      �� *	CostSum+$
 TwoWay=�$ PropertyChanged=��� 5X      $ 
Horizontal=�6!   .+�5Y      �� -   5         ��Name$ btnSend��5Y   !   $��1��5Z   !   $	��100��5[   !   $��30��5\   !   $��15(�5]   !   $��Добавить��5^   !   
������ $��25 0 0 0q�5`   !   ��5a   !   �� *
ClickAdd+ � 	Resources 5b       �� 
TargetType �� Property �� Value��%_   '��       �� 5c   "   " ��6(   .�5d   &   ��  �@��CornerRadius$ 15��6E   5e   #   5f      5g      �� 5h      -   5        $ 	btnDelete��5h   !   $��1��5i   !   $	��100��5j   !   $��30��5k   !   $��15(�5l   !   $��Удалить��5m   !   
������ $��50 0 0 0q�5o   !   ��5p   !   �� *ClickDelete+ 5q      ��%_   '��       �� 5r   "   " ��6(   .�5s   &   ��  �@��CornerRadius$ 15��6E   5t   #   5u      5v      5w      5x      5y      � 5z      $��1��6    5{      �� 5|      $��4* �6$   �� 5}      $��1* �6$   .+�5      &   System.Windows.Controls.DataGrid  $��0��6   $��25 25 25 25q�5�         AutoGenerateColumns .     
IsReadOnly . ��5�      �� *Costs+$
 TwoWay=�$ PropertyChanged=�	 5�      �� *SelectedCost+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      -   5        ColumnUserName��,	  &System.Windows.Controls.DataGridColumn 	  Header$ Имя��5�   )    	  Width 5�   )   ��  �� ElementName$ ColumnUserName�� �� Path$ 
FontWeight�1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5�   )   �� *	User.Name+  5�      -   5        ColumnCostName��$$ На что потрачено��5�   )   5  /System.Windows.Controls.DataGridLengthConverter$ 3* 5�   )    5�   )   �� *
CostName+  5�      -	   5        	ColumnSum��$ 
Сумма��5�   )   $ 2* 5�   )    5�   )   �� *Sum+  5�      -
   5        
ColumnDate��$ Дата��5�   )    5�   )   �� $ 
ColumnDate��$ 
FontWeight� 5�   )   �� *Date+ �� StringFormat$ 
dd-MM-yyyy��5�      �� 5�      $��1��6   $ 
Horizontal=�5�      .+�5�      �� $	��200��6    $��
25 0 25 50q�5�      $��35��5�      $��15(�5�      $0��*Итоговая сумма за день:��5�      �� 5�      $	��125��6    $��35��5�      $��15(�5�      $��	0 0 25 50q�5�      ��5�      �� *
TotalSum+$
 TwoWay=�$ PropertyChanged=�5�      5�      5�      5�      5�      