   M S B A M L   `   `   `  ����  QRandClockIn    QRandClockIn.LogInPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5         loginMouseEnter g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  registerMouseEnter  loginMouseLeave  registerMouseLeave��%@  &	        &	 �    &	 �    &	 �    �� 5	   
   .��5
      U� $ 00:00:00X�6,   $ loginTextBlock��6A   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6h   .\�5      �� $ 00:00:00.2000000��6'   $	 1.2Q�6B   5      U� 5      $ 00:00:00X�6,   $ loginTextBlock��6A   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6h   .\�5      �� $ 00:00:00.2000000��6'   $	 1.2Q�6B   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ registerTextBlock��6A   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6k   .\�5      �� $ 00:00:00.2000000��6'   $	 1.2Q�6B   5      U� 5      $ 00:00:00X�6,   $ registerTextBlock��6A   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6k   .\�5      �� $ 00:00:00.2000000��6'   $	 1.2Q�6B   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ loginTextBlock��6A   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6h   .\�5      �� $ 00:00:00��6'   $	 1.2Q�6:   �� 5      $ 00:00:00.2000000��6'   $ 1Q�6B   5      U� 5       $ 00:00:00X�6,   $ loginTextBlock��6A   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6h   .\�5!      �� $ 00:00:00��6'   $	 1.2Q�6:   �� 5"      $ 00:00:00.2000000��6'   $ 1Q�6B   5#      5$      �� 5&   
   .��5'      U� $ 00:00:00X�6,   $ registerTextBlock��6A   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6k   .\�5(      �� $ 00:00:00��6'   $	 1.2Q�6:   �� 5)      $ 00:00:00.2000000��6'   $ 1Q�6B   5*      U� 5+      $ 00:00:00X�6,   $ registerTextBlock��6A   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6k   .\�5,      �� $ 00:00:00��6'   $	 1.2Q�6:   �� 5-      $ 00:00:00.2000000��6'   $ 1Q�6B   5.      5/      55       � Triggers 56      .��5;      � .+�5<   
   �� $
��Bold"�6   $��20(�6&   
���   �$
��Left=�6H   $��
40,144,0,0q�6c   $��Username��6w    �� TextAlignment$ Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $	��112��6�   $��27��6�   $��Bell MT)�6�     Text#��[ 6�    J� Effect 6  3  -System.Windows.Media.Effects.DropShadowEffect  6(  	   
BlurRadius$	 6Q�69  
   Color$
 	#FF797979��6H     	Direction$	 201Q�6Z     Opacity$
 0.68Q�6j     ShadowDepth$ 3Q�6y  6�  �� 5=   
   $
��Bold"�6   $��20(�6&   
���   �$
��Left=�6H   $��
40,180,0,0q�6c   $��Password��6w   $ Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $	��112��6�   $��Bell MT)�6�   #��[ 6�    6
    6  $	 6Q�6-  $
 	#FF797979��6<  $	 201Q�6N  $
 0.68Q�6^  $ 3Q�6m  6�  �� 5>   
   -   5        $��ClerkLoginUserNametxt��5>   �   $��12(�6   
���   �$��Center=�64   $��231,144,58,0q�6Q    �� TextAlignment$
 Left=�6h    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $	��211��6�   $��27��6�   6�   G� 5?   
   -   5        $��ClerkLoginPasswordtxt��5?   �   $��12(�6   
���   �$��27��68   $��Center=�6D   $��231,177,58,0q�6a   $	��Top=�6w   $	��211��6�   $y�Visible=�6�   �� 5A   
   -   5        $��20(�5A   )   $��Sign In��67   $��158,0,182,206q�6I   $
��Bold"�6`   $��Bottom=�6r   $��30��6�   $	��160��6�     GlassButtonStyle#��[ 6�   6�   �� 5B   
   $��25(�6   $
��Bold"�6"   
���   �$
��Left=�6G   $��128,357,0,0q�6b   $'��!Software Engineering Project 2017��6w   $ Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $	��263��6�   #��[ 6�    5C        5D      $	 6Q�6#   $
 	#FF797979��62   $	 201Q�6D   $
 0.68Q�6T   $ 3Q�6c   5E   "   5F      5G      