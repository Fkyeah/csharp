   M S B A M L   `   `   `  ���� G  CCost_Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Cost_Control.ReportsCost_Control.Reports  &     Cost_Control.Reports.ReportsView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:Cost_Control.Reports     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  .��� .+��   � ColumnDefinitions  �� �� .+�� $��0�� � RowDefinitions �� $��3* ��� $��2* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ cbCurrentUser��$��0��$
��Left=�$	��Top=�$	��140��$��	25 25 0 0q����� *Users+ �� SelectedItem �� *SelectedName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�&   System.Windows.Controls.Calendar  -     Name$ Calendar��$��0��$
��Left=�$	��Top=�$��	25 22 0 0q�   SelectedDate �� *SelectedDate+$ TwoWay=�$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction	   Triggers	 /  )System.Windows.Interactivity.EventTrigger  
   	EventName$
 SelectedDatesChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *DateChangedCommand+�� $��2��$ 
Horizontal=�$	��Top=�.+�(  "System.Windows.Controls.DatePicker  $
��25 0q�   SelectedDate �� *
FromDate+$ TwoWay=�$ PropertyChanged=�  $
��65 0q� �� *ToDate+$ TwoWay=�$ PropertyChanged=��� -    ��Name$ 
btnGetStat��$��2��$	��170��$��30��$��15(�$
��Left=�$��25 0 0 0q�$(��"Показать за период��
������ ���� *	GetStat+ � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 15��&   System.Windows.Controls.DataGrid  $��1��$��2��$��25 25 25 50q�   
IsReadOnly .    AutoGenerateColumns .  ���� *CostsForReports+$ TwoWay=�$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   ColumnUserName��,	  &System.Windows.Controls.DataGridColumn 	  Header$ Имя�� 	  Width ��  �� ElementName$ ColumnUserName�� �� Path$ 
FontWeight�1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *	User.Name+  -   ColumnCostName��$$ На что потрачено��5  /System.Windows.Controls.DataGridLengthConverter$ 3*  �� *
CostName+  -   	ColumnSum��$ 
Сумма��$ 2*  �� *Sum+