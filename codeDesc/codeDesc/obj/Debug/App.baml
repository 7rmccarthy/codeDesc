   M S B A M L   `   `   `  ����C  ?codeDesc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:codeDesc.StyleableWindowcodeDesc.StyleableWindow  5          codeDesc.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      5sw&clr-namespace:codeDesc.StyleableWindow     5        �� 	Resources  5       �� MergedDictionaries �� Source   HighlightBrush  
Primary700 �� Color  AccentColorBrush  
Primary500  AccentColorBrush2  
Primary400  AccentColorBrush3  
Primary300  AccentColorBrush4 	 
Primary200 
 WindowTitleColorBrush  AccentSelectedColorBrush  Primary500Foreground  ProgressBrush �� EndPoint �� 
StartPoint � Color � Offset  CheckmarkFill  RightArrowFill  IdealForegroundColorBrush   IdealForegroundDisabledBrush �� Opacity  WindowColor  WindowBackColor  WindowForeColor  WindowForeHighlightColor  WindowButtonColor  WindowButtonOverColor  WindowButtonPressedColor4   .codeDesc.StyleableWindow.WindowMinimizeCommand  MinimizeCommand4   .codeDesc.StyleableWindow.WindowMaximizeCommand  MaximizeCommand1   +codeDesc.StyleableWindow.WindowCloseCommand  CloseCommand  ImageSrc	 �� 
TargetType  WindowButton
 �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  
WindowIcon  WindowTemplate � RowDefinitions � ColumnDefinitions9   3codeDesc.StyleableWindow.ControlDoubleClickBehavior   ExecuteCommand   ExecuteCommandParameter �� RelativeSource �� Mode �� AncestorType �� Path5   /codeDesc.StyleableWindow.ShowSystemMenuBehavior   TargetWindow   LeftButtonShowAt �� ElementName � Title   RightButtonShow1   +codeDesc.StyleableWindow.WindowDragBehavior   LeftMouseButtonDrag �� Orientation ��Name  ��Name! ��Name" n�Name# � Cursor$ J� Opacity3   -codeDesc.StyleableWindow.WindowResizeBehavior%   	TopResize&   TopLeftResize'   BottomResize(   TopRightResize)   RightResize*   BottomRightResize+   
LeftResize,   BottomLeftResize- ]� 
Conditions. �� Property/ �� Value0 �� 
TargetName   CustomWindowStyle ! StandardBorderBrush " StandardBackgroundBrush # HoverBorderBrush $ SelectedBackgroundBrush % SelectedForegroundBrush & DisabledForegroundBrush ' NormalBrush ( NormalBorderBrush ) HorizontalNormalBrush * HorizontalNormalBorderBrush + ListBoxBackgroundBrush , StandardBrush - 
GlyphBrush . PressedBrush / ScrollBarLineButton1 �� CornerRadius 0 ScrollBarPageButton 1 ScrollBarThumb 2 VerticalScrollBar2 ]� DecreaseRepeatButton3 ]� Thumb4 ]� IncreaseRepeatButton 3 HorizontalScrollBar5 �� Triggers 4 FavsScrollViewer6 �� VerticalOffset7 � Value8 �� ScrollableHeight9 � Maximum: �� ViewportHeight; �� ViewportSize*< �� #ComputedVerticalScrollBarVisibility= �� Orientation> �� HorizontalOffset? �� ScrollableWidth@ �� ViewportWidth,A �� %ComputedHorizontalScrollBarVisibility�� 5	   
    5
      �� 5      $d ^pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml?�5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�5      �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�5      �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Blue.xaml?�5      %�+  &	        &	      &	 4     &	 N     &	 h     &	
 �     &	 �     &	 �     &	 H    &	 b    &	 |    &	 �    &	 �    &	 �    &	 �    &	     &	 ;    &	 U    &	 o    &	 �    &	 �    &	 �    &	 �    &	 �    7  7  7  7  7  7  7  7  &	 �    &	 �    7  7  7  7  7  7  7  7  7  7  7  &	  �    7  &	! %    &	" C    &	# a    &	$     &	% �    &	& �    &	' �    &	( �    &	)     &	* 4    &	+ R    &	, 6    &	- �    &	.     &	/ 
    7 ' 7 ( 7 - 7 . 7 & &	0 �    &	1 �    &	2 j    7 / 7 0 7 1 7 ) 7 * 7 0 7 / &	3 �!    7 / 7 0 7 1 7 ' 7 ( 7 0 7 / '�� �$    7 3 7 2 &	4 �&    �� 5      # �  65   �� 5      # �  67   �� 5      # �  68   �� 5      # �  68   �� 5      # � 	 68   �� 5      # �  6<   �� 5      # �  6?   �� 5       $ 	0.001,0.5&�68   $ 	1.002,0.5&�6M   .��5!      � # �  6   $ 0Q�6D   � 5"      # �  6   $ 1Q�6D   5#      �� 5$      # �  64   �� 5%      # �  65   �� 5&      # �  6@   �� 5'      # �  6C   $	 0.4Q�6h   �� 5*      # �  62   �� 5+      # �  66   �� 5,      $ 
WhiteSmoke��66   �� 5-      $ 
WhiteSmoke��6?   �� 5.      # �  68   �� 5/      # �  6<   �� 50      $ DarkBlue��6?     53      6'     54      6'     55      6$     56      6'   �� 59      "	 ��6   .�5:      �� 
 � ��$ 25��6+   �� 5;      
 � ��$ 25��6*   �� 5<      
 � ��8   6/   �� 5=      
 � ��8  6/   �� 5>      
 � �� 5?      �� 5@      " ��6*   .R�5A      �� #��z��6%   ._�5B   "   �� $��Center=�63   $��Center=�6P   5C       5D      P� 5E   "    � {� .  . �5F   &   �� 8  
 � ��6C   �� 5G   &   8  
 � ��6C   5H   #   P� 5I   "    �@J�IsMouseOver . . �5J   &   �� 8  
 � ��6C   �� 5K   &   8  
 � ��6C   5L   #   P� 5M   "    � �� . . �5N   &   �� 8  
 � ��6C   �� 5O   &   8  
 � ��6C   5P   #   5R      5T      5U      �� 5b      "	 ��6   .�5c      �� 
 � ��$ 15��6+   �� 5d      
 � ��$ 15��6*   5e      �� 5h      " �65   .R�5i      � 8��  .+�5j      �  5k      �� 5l      $��30 �6,   �� 5m      $��* �6,   .+�5o      � $��0��6   $��5,0,5,0q�6,    5p      �� 5q   "   $
��auto �63   �� 5r   "   $��* �63   �� 5s   "   $��75 �63   .+�5u      �� $��0��6$   8  $��0q�5w   �    6%   ��  �� $ FindAncestor=�" �.��5x   "   �� $
��Left=�6(   8�� $��16��5y   %   ��5x   b   ��  �� $ FindAncestor=�" �$
 Icon� 5z   %   ��  �� $ FindAncestor=�" � 5{   %   �� $ WindowContent��5|      �� 5}      $��1��6$   $
��Left=�64   #��z 6J   $��3,0,0,0q�6u   $
��Left=�5~   %   $��Center=�5   %   $��Stretch=�5�   %   $��Stretch=�5�   %   8�� $��16(�5�   %   8   .  5�   %   ��  �� $ FindAncestor=�" � 5�   %   ��  �� $ FindAncestor=�" � 5�   %   ��  �� $ FindAncestor=�" �5�      �� 5�      $��2��6)   $ 
Horizontal=�69   .+�5�   "   �� $��Right=�6)   8�� 8�� ��6�   ��  �� $ FindAncestor=�" �.��5�   &   �� $��Minimize_icon��6,   $��../Icons/Minimize_btn.png��6A   #���  6d   5�   #   �� 5�   "   $ Maximize_btn��6@   $��Right=�6)   8�� 8�� ��6�   ��  �� $ FindAncestor=�" �.��5�   &   �� $��Maximize_icon��6,   #���  6�   ��6A   �� $ 
IconSource� �� *FindAncestor+" �6�   5�   #   �� 5�   "   $��Right=�6)   8��	 8��
 ��6�   ��  �� $ FindAncestor=�" �.��5�   &   �� $��
Close_icon��6,   $��../Icons/Close_btn.png��6>   #���  6^   5�   #   5�      5�      �� 5�      $��1��6!   #��z��6.   #��z��6Z   #��z��6�   ._�5�      � .+�5�   "   �� .u�5�   &   �� $  WindowContent��67   5�   #   �� 5�   "   $! WindowResizeGrip��6.   $��Right=�6H   ��.  $y�	Collapsed=�6v   $��Bottom=�6�   5�      5�      5�      n� 5�      $" ThumbTop��6   $��6��6.   $
��14,0q�69   $	��Top=�6G   $# SizeNS��6_   $$ 0Q�6p   % 6|   ��  �� $ FindAncestor=�" �n� 5�      $" ThumbTopLeft��6   $��6��62   $��6��6=   $	��Top=�6G   $
��Left=�6_   $# SizeNWSE��6z   $$ 0Q�6�   & 6�   ��  �� $ FindAncestor=�" �n� 5�      $" ThumbBottom��6   $��6��61   $
��14,0q�6<   $��Bottom=�6J   $# SizeNS��6e   $$ 0Q�6u   ' 6�   ��  �� $ FindAncestor=�" �n� 5�      $" ThumbTopRight��6   $��6��63   $��6��6>   $	��Top=�6H   $��Right=�6`   $# SizeNESW��6|   $$ 0Q�6�   ( 6�   ��  �� $ FindAncestor=�" �n� 5�      $" 
ThumbRight��6   $��Right=�60   $
��0,14q�6L   $��6��6Z   $# SizeWE��6d   $$ 0Q�6u   ) 6�   ��  �� $ FindAncestor=�" �n� 5�      $" ThumbBottomRight��6   $��6��66   $��6��6A   $��Bottom=�6K   $��Right=�6f   $# SizeNWSE��6�   $$ 0Q�6�   * 6�   ��  �� $ FindAncestor=�" �n� 5�      $" 	ThumbLeft��6   $
��Left=�6/   $
��0,14q�6J   $��6��6X   $# SizeWE��6b   $$ 0Q�6s   + 6   ��  �� $ FindAncestor=�" �n� 5�      $" ThumbBottomLeft��6   $��6��65   $��6��6@   $��Bottom=�6J   $
��Left=�6e   $# SizeNESW��6�   $$ 0Q�6�   , 6�   ��  �� $ FindAncestor=�" �5�       5�      ]� 5�      - 5�      �� 5�      . �@�
ResizeMode$/ CanResizeWithGrip=�6>   �� 5�      . �@�WindowState$/ Normal=�6?   ./�5�      �� $0 WindowResizeGrip��67   
 � y�$ Visible=�6U   5�      5�      �� 5�      "	 �6.   CustomWindowStyle��.�5�      �� 
 �@�WindowStyle$
 None=�60   �� 5�      
 �@�AllowsTransparency . 67   �� 5�      
 � ��$	 200��6-   �� 5�      
 � ��$ 46��6.   �� 5�      
 � ��# �  60   �� 5�      
 � ��$ 5q�64   �� 5�      
 � ��
 �����6/   �� 5�      
 � ��8   6-   5�      �� 5�      $
 #888��6:   �� 5�      $
 #FFF��6>   �� 5�      $
 #DDD��67   �� 5�      $
 Gray��6>   �� 5�      $ White��6>   �� 5�      $
 #888��6>   �� 5�      $
 #888��62   �� 5�      $
 #888��68   �� 5�      $
 #888��6<   �� 5�      $
 #888��6B   �� 5�      $	 0,0&�5�      $ 1,0.001&�6   ��5�      � � 5�      $ White��6'   $	 0.0Q�65   � 5�      $ White��6'   $	 0.6Q�65   � 5�      $ #DDDDDD��6'   $	 1.2Q�67   5�      5�      �� 5�      $	 0,0&�5�      $	 0,1&�6   ��5�      � � 5�      $
 #FFF��6'   $	 0.0Q�64   � 5�      $
 #CCC��6'   $	 1.0Q�64   5�      5�      �� 5�      $
 #444��61   �� 5�      $	 0,0&�5�      $	 0,1&�6   ��5�      � � 5�      $
 #BBB��6'   $	 0.0Q�64   � 5�      $
 #EEE��6'   $	 0.1Q�64   � 5�      $
 #EEE��6'   $	 0.9Q�64   � 5�      $
 #FFF��6'   $	 1.0Q�64   5�      5�      �� 5�      "	 ��60   .�5�      �� 
 �@J�SnapsToDevicePixels . 68   �� 5�      
 �@�OverridesDefaultStyle . 6:   �� 5�      
 � |� .  6.   �� 5�      
 � �� 5�      �� 5�      " ��6*   .R�5�      �� $��Border��5�      $��1q�5�      $1 2��5�      8��  8�� $��1q�5�      ._�5�   "   F� $��Center=�5�      $��Center=�5      8�� ��5     �� $ Content� �� *TemplatedParent+5      5     P� 5  "    � �� . . �5  &   �� $0 Border��6-   8  
 � ��5  !   5	  #   P� 5
  "    � {� .  . �5  &   �� 8  
 � ��5  !   5  #   5     5     5     �� 5     "	 ��60   .�5     �� 
 �@J�SnapsToDevicePixels . 68   �� 5     
 �@�OverridesDefaultStyle . 6:   �� 5     
 � �� .  6.   �� 5     
 � |� .  6.   �� 5     
 � �� 5     �� 5     " ��6*   .R�5     �� 
������ 6%   5     5      5!     �� 5$     "	 n�6+   .�5%     �� 
 �@J�SnapsToDevicePixels . 68   �� 5&     
 �@�OverridesDefaultStyle . 6:   �� 5'     
 � �� .  6.   �� 5(     
 � |� .  6.   �� 5)     
 � �� 5*     �� 5+     " n�6*   .R�5,     �� $1 2��5-     #��z��5.     #��z��5/     $��1q�50     51     53     54     �� 56     " ��57     .R�58     �  59     �� 5:     $��18��6(   �� 5;     $��0.00001* �6(   �� 5<     $��18��6(   .+�5>     �� $��3��5?     $1 2��5@     ���#F0F0F05A     �� 5B     $��0��5C     8��  $��18��5E     $��ScrollBar.LineUpCommand��5F     $��M 0 4 L 8 4 L 4 0 Z��5G     ]� 5H     $��
PART_Track��5I     $��1��5J     ��. 2 5L     �� 5M     8�� $��ScrollBar.PageUpCommand��5O     3 5Q     n� 5R     8�� $��1,0,1,0q�5T     8�� 8�� 5V     4 5X     �� 5Y     8�� $��ScrollBar.PageDownCommand��5[     5]     �� 5^     $��3��5_     8�� $��18��5a     $��ScrollBar.LineDownCommand��5b     $��M 0 0 L 4 4 L 8 0 Z��5c     5d     5e     �� 5g     " ��5h     .R�5i     �  5j     �� 5k     $��18��6+   �� 5l     $��0.00001* �6+   �� 5m     $��18��6+   .+�5o     �� $��3��5p     $1 2��5q     ���#F0F0F05r     �� 5s     $��0��5t     8��  $��18��5v     $��ScrollBar.LineLeftCommand��5w     $��M 4 0 L 4 8 L 0 4 Z��5x     ]� 5y     $��
PART_Track��5z     $��1��5{     ��.  2 5}     �� 5~     8�� $��ScrollBar.PageLeftCommand��5�     3 5�     n� 5�     8�� $��0,1,0,1q�5�     8�� 8�� 5�     4 5�     �� 5�     8�� $ ��ScrollBar.PageRightCommand��5�     5�     �� 5�     $��3��5�     8�� $��18��5�     $ ��ScrollBar.LineRightCommand��5�     $��M 0 0 L 4 4 L 0 8 Z��5�     5�     5�     �� 5�     "	 ��6/   .�5�     �� 
 �@J�SnapsToDevicePixels . 68   �� 5�     
 �@�OverridesDefaultStyle . 6:   5 5�     P� 5�      �@��Orientation$ 
Horizontal=�65   . �5�     �� 
 � ��$
 Auto��62   �� 5�     
 � ��$ 18��63   �� 5�     
 � ��8   5�     5�     P� 5�      �@��Orientation$ Vertical=�65   . �5�     �� 
 � ��$ 18��62   �� 5�     
 � ��$
 Auto��63   �� 5�     
 � ��8  5�     5�     5�     �� 5�     "	 ��6-   .�5�     �� 
 �@�OverridesDefaultStyle . 6:   �� 5�     
 � �� 5�     �� 5�     " ��6*   .R�5�     �  5�  "   �� 5�  &   $
��Auto �67   �� 5�  &    5�  "   �� 5�  &   �� 5�  &   $
��Auto �64   .+�5�  "   �� $��1��69   �� 5�  "   $��PART_VerticalScrollBar��6,   #7 z6 5�     #9 z8 5�     #; z: 5�     #y�z< 5�     �� 5�  "   $��PART_HorizontalScrollBar��6,   $= 
Horizontal=�5�     $��1��5�     $��1��5�     #7 z> 5�     #9 z? 5�     #; z@ 5�     #y�zA 5�     5�     5�     5�     5�     5�     5�     