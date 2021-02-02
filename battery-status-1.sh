# https://www.2daygeek.com/linux-low-full-charging-discharging-battery-notification/

#!/bin/bash
   while true
    do
       export DISPLAY=:0.0
       battery_level=`acpi -b | grep -P -o '[0-9]+(?=%)'`
       if on_ac_power; then
           if [ $battery_level -ge 95 ]; then
              notify-send "Battery Full" "Level: ${battery_level}% "
              paplay /usr/share/sounds/freedesktop/stereo/suspend-error.oga
           fi
       else
           if [ $battery_level -le 30 ]; then
              notify-send --urgency=CRITICAL "Battery Low" "Level: ${battery_level}%"
              paplay /usr/share/sounds/freedesktop/stereo/suspend-error.oga
           fi
       fi
     sleep 60
done
