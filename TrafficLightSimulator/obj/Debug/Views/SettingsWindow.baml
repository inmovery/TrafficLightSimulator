   M S B A M L   `   `   `  ����P  LTrafficLightSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TrafficLightSimulatorTrafficLightSimulator  5   	   S OTimePickerControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:TimePickerControlLibrary;assembly=TimePickerControlLibraryTimePickerControlLibrary 5   	   S.clr-namespace:TrafficLightSimulator.Converters TrafficLightSimulator.Converters  5   	   *    $TrafficLightSimulator.SettingsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:TrafficLightSimulator     5   	   [customHclr-namespace:TimePickerControlLibrary;assembly=TimePickerControlLibrary     5   	   >cnv.clr-namespace:TrafficLightSimulator.Converters     5   	     � WindowStyle$
  None=�5
   	    � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	    � Title$ Settings��5   	   $	��380��6   $	��350��6'    � 	Resources 5      :   4TrafficLightSimulator.Converters.ModeManualConverter   ModeManualConverter=   7TrafficLightSimulator.Converters.ModeAutomaticConverter  ModeAutomaticConverterD   >TrafficLightSimulator.Converters.ModeAutomaticEnabledConverter ! ModeAutomaticEnabledConverterA   ;TrafficLightSimulator.Converters.ModeManualEnabledConverter  ModeManualEnabledConverter*   $TrafficLightSimulator.SettingsWindow �� 
TargetType �� Property �� Value �� 
TargetType	 �� Padding
 �� FallbackValue ��Name  BackgroundLightBrush �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity J� OpacityMask !� Visual �� ElementName � RowDefinitions K� ZIndex � ColumnDefinitions  	Hoverless  
HeaderText �� Orientation  WindowControlButton  IconMinimize 	 IconMaximize 
 WindowCloseButton  IconExit �� Color �� Opacity��%�  &	        &	      &	 &     &	 9     '  L     7  7  7  7  7  7  7 	 7 
 7    5   
   6"     5   
   6%     5   
   6,     5   
   6)   �� 5   
   "  6   .�5      ��  � �� 5      �� 5      " �6&   .R�5      �� 	 6!   �� *OuterMarginSizeThickness+$
 5��._�5      � .+�5   "   �� $ 	Container��5   %   8��   5    %   �� *WindowCornerRadius+$
 0���� 5#   "    6)   �� *WindowCornerRadius+$
 0����5$   )   �� *ForegroundLightBrush+$
 White�� 5%   &     5&   *   $ 0Q�6;   $	 0.2Q�6K   5(   #   � 5+   "    5.   &   !� 5/   *    66   �� $ 	Container�� 52   &   �� 54   *   ��68   �� *TitleHeightGridLength+$
 35���� 56   *   $
��Auto �68   �� 58   *   $��* �68   .+�5<   &   � $��0��6+   $ 1��68    5>   *   �� 5?   .   $
��Auto �6?   �� 5@   .   $��* �6?   .+�5D   *   �� $��0��61   8�� ��6d   �� *MenuCommand+.��5E   .   �� 8�� $��Settings��6\   $
��Auto��6l   5F   +   �� 5H   *   $��1��65   $ 
Horizontal=�6E   $��Right=�6^   .+�5J   .   �� $��
10 15 10 0q�6Y   8�� ��65   �� *MinimizeCommand+.��5K   2   �� 8�� 6A   5L   /   �� 5M   .   $��	10 4 10 0q�6Y   8�� ��65   �� *MaximizeCommand+.��5N   2   �� 8�� 6A   5O   /   �� 5P   .   8�� ��65   �� *CloseCommand+.��5Q   2   �� 8�� 6A   5R   /   5S   +   5U   '   �� 5X   &   $��1��6-   $��6��6:   $��0 1 0 0q�6E   ��5Z   *   �� 5[   .   $ Black��6>   $
 0.05Q�6L   5^   '   �� 5a   &   $��2��6-   	 6:   �� *InnerContentPadding+._�5b   *   �� #��z��6;   5c   '   5d   #   5e      5f      5g      5i      5j      5k      '  !System.Windows.Shell.WindowChrome   WindowChrome 5m        5n   
      CornerRadius$ 0��5q         GlassFrameThickness$ 0q�5r         ResizeBorderThickness 5o      �� *ResizeBorderThickness+   CaptionHeight 5p      �� *TitleHeight+5r      .��5u      � .+�5v   
   �� $ Vertical=�6   $��Center=�6,   .+�5w      �� $ 
Horizontal=�6   $��Center=�62   $��0 20 0 0q�6O   .+�5x      �� $��Режим работы��5y      $��16(�5z      $��Center=�5{      $��0 0 20 0q�5|      
���   �5}      �� 5~      $	��150��5      $
��Auto��5�      $��30��5�      $
��Left=�5�      $��14(�5�        CustomComboBox#��[ 5�        CustomComboBoxItem#��[ 5�      ��5�      �� *	ModesView+ �� SelectedIndex 5�      �� *TrafficLightInfo.ModeIndex+ �� SelectedItem 5�      �� * TrafficLightInfo.ModeOperation+  �� Mode$  TwoWay=�! �� UpdateSourceTrigger$! PropertyChanged=�5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� -   5        $ BorderDurations��5�      $��0 20 0 0q�5�      $ 5��5�      $	 5q�5�      {�5�      �� *&$TrafficLightInfo.ModeOperation.Value+$! PropertyChanged=�" �� 	Converter#" [ ��5�      �� *&$TrafficLightInfo.ModeOperation.Value+$! PropertyChanged=�#" [ ._�5�      �� $ Vertical=�5�      $��Center=�5�      .+�5�      �� $+��%Длительность работы��5�      $��16(�5�      
���   �5�      �� 5�      $ Vertical=�6%   .+�5�      )  #TimePickerControlLibrary.TimePicker  $��1��5�   !   
���  ��$	��1.5q�5�   !   $��0 10 0 0q�5�   !   $��18(�5�   !   #   SelectedTime# 5�   !   �� *$"TrafficLightInfo.DurationRed.Value+$  TwoWay=�  5�      $��1��5�   !   
��� ���$	��1.5q�5�   !   $��0 10 0 0q�5�   !   $��18(�5�   !   # 5�   !   �� *'%TrafficLightInfo.DurationYellow.Value+$  TwoWay=�  5�      $��1��5�   !   
��� � �$	��1.5q�5�   !   $��0 10 0 0q�5�   !   $��18(�5�   !   # 5�   !   �� *&$TrafficLightInfo.DurationGreen.Value+$  TwoWay=�5�      �� 5�      $	��125��5�      $��35��5�      $��0 10 0 0q�5�      $��14(�5�      $
��Bold"�5�        ApplyChangesButton#��[ 5�      $��Применить��5�      ��5�      �� *ApplyChanges+5�      5�      5�      �� 5�      -   5        $ BorderManagment��5�      $��	40 20 0 0q�5�      $ 5��5�      $	 5q�5�      {�5�      �� *&$TrafficLightInfo.ModeOperation.Value+$! PropertyChanged=�#" [ ��5�      �� *&$TrafficLightInfo.ModeOperation.Value+$! PropertyChanged=�#" [  ._�5�      �� $ Vertical=�6!   .+�5�      �� $��Управление��5�      $��16(�5�      $��Center=�5�      
���   �5�      �� 5�      $ Vertical=�6%   .+�5�      �� $��50��5�   !   $��50��5�   !     CircleButton#��[ 5�   !   
���  ��$��0 10 0 0q�5�   !   ��5�   !   �� *EnableRedLight+�� 5�      $��50��5�   !   $��50��5�   !   #��[ 5�   !   
��� ���$��0 15 0 0q�5�   !   ��5�   !   �� *EnableYellowLight+�� 5�      $��50��5�   !   $��50��5�   !   #��[ 5�   !   
��� � �$��0 15 0 0q�5�   !   ��5�   !   �� *EnableGreenLight+5�      5�      5�      5�      5�      5�      5�      