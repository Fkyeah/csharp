   M S B A M L   `   `   `  ���� G  CCost_Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Cost_Control.CostManagerCost_Control.CostManager  .    (Cost_Control.CostManager.CostManagerView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  /vm&clr-namespace:Cost_Control.CostManager    � DataContext  3  -Cost_Control.CostManager.CostManagerViewModel  .  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Closing��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *WindowClosing+.��� .+��  � ColumnDefinitions �� �� .+�� $��0�� � RowDefinitions �� �� .+��� $��0�� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ cbCurrentUser��$
��Left=�$	��Top=�$	��140��$��	25 25 0 0q����� *Users+	 �� SelectedItem	 �� *SelectedName+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   $ SelectionChanged��.    �� *CurrentUserChangedCommand+&   System.Windows.Controls.Calendar  -     Name$ Calendar��$��0��$��Right=�$	��Top=�$	��165��$��	25 22 0 0q�   SelectedDate �� *SelectedDate+$
 TwoWay=�$ PropertyChanged=�   $ SelectedDatesChanged��.    �� *DateChangedCommand+�� $��1��.+��� $$��На что потрачено��$��1��$��25 0 0 0q�$��15(��� -    ��Name$ 
tbCostName��$��1��$	��250��$��35��$��15(�$	��Top=�$
��Left=�$��Center=�$��25 5 0 0q����� *
CostName+$
 TwoWay=�$ PropertyChanged=�.���� $��
Сумма��$��1��$��25 5 0 0q�$��15(��� -   $ tbSum��$��1��$	��250��$��35��$��15(�$��Center=�$
��Left=�$��Center=�$��	25 5 0 20q����� *	CostSum+$
 TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�.+��� -    ��Name$ btnSend��$��1��$	��100��$��30��$��15(�$��Добавить��
������ $��25 0 0 0q����� *
ClickAdd+ � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 15���� -   $ 	btnDelete��$��1��$	��100��$��30��$��15(�$��Удалить��
������ $��50 0 0 0q����� *ClickDelete+ ��%:   '��       �� " ��.���  �@��CornerRadius$ 15��� $��1�� �� $��4* ��� $��1* �.+�&   System.Windows.Controls.DataGrid  $��0��$��25 25 25 25q�   AutoGenerateColumns .     
IsReadOnly . ���� *Costs+$
 TwoWay=�$ PropertyChanged=�	 �� *SelectedCost+   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   ColumnUserName��,	  &System.Windows.Controls.DataGridColumn 	  Header$ Имя�� 	  Width ��  �� ElementName$ ColumnUserName�� �� Path$ 
FontWeight�1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *	User.Name+  -   ColumnCostName��$$ На что потрачено��5  /System.Windows.Controls.DataGridLengthConverter$ 3*  �� *
CostName+  -	   	ColumnSum��$ 
Сумма��$ 2*  �� *Sum+  -
   
ColumnDate��$ Дата�� �� $ 
ColumnDate��$ 
FontWeight� �� *Date+ �� StringFormat$ 
dd-MM-yyyy���� $��1��$ 
Horizontal=�.+��� $	��200��$��
25 0 25 50q�$��35��$��15(�$0��*Итоговая сумма за день:���� $	��125��$��35��$��15(�$��	0 0 25 50q����� *
TotalSum+$
 TwoWay=�$ PropertyChanged=�