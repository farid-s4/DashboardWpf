   M S B A M L   `   `   `  ����D  @Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Dashboard	Dashboard  5   	       Dashboard.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:Dashboard     5   	     � Title$  Главное окно��5   	   $	��950��6   $
��1000��6+    � 	Resources 5         ModernButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   Color   	Direction   ShadowDepth   Opacity   
BlurRadius �� ScaleX �� ScaleY��%�  &	        �� 5   
   " ��6*   .�5      ��  � �� �	#FF4A90E26+   �� 5	       � ��
 �����6+   �� 5
       � ��$ 0q�60   �� 5       � ��$ 14(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 20,12q�6(   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��5   !   $ 8��5   !   #��z��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�5   -   #��z��5   -   5       5      P� 5      	 �@J�IsMouseOver$

 True��6=   . �5   "   �� $ border��6)    � �� �	#FF357ABD6S   �� 5   "    �@J�Effect 5   &     5    *   $ Black��6;   $	 270Q�6I   $ 2Q�6Y   $	 0.3Q�6i   $ 8Q�6w   5"   #   5#      P� 5$      	 � ��$

 True��6;   . �5%   "   �� $ border��6)    � �� �	#FF2E6BA86S   �� 5&   "    � z� 5'   &   �� 5(   *   $
 0.98Q�69   $
 0.98Q�6G   5*   #   5+      P� 5,      	 � {�$
 False��6;   . �5-   "   �� $ border��6)    � �� �	#FFAAAAAA6S   �� 5.   "    � �� �	#FF6666666?   5/      51      53      54      55      .��57      � ���	#FFF8F9FA.+�58   
   �� -   5         ��Name$ NavigationPanel��58       �� Orientation$ 
Horizontal=�59      $��Center=�5:      $��Center=�5;      $	��244��5<      .+�5=      �� -   5        $��📅 Расписание��5=      $	��160��5>      $��50��5?      $��15q�5@      #��[  5B      �� 5C      -   5        $0��*💰 Финансовый менеджер��5C      $	��250��5D      $��50��5E      $��15q�5F      #��[  5H      5I      �� 5J   
   -   5         ��Name$ MainContent��5J      5K      5L      