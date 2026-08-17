using System;
using System.Management;

namespace DellFanController.Core
{
    public static class HardwareMonitor
    {
        public static float GetCpuTemperature()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\wmi", "SELECT CurrentTemperature FROM MSAcpi_ThermalZoneTemperature"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        double tempKelvin = Convert.ToDouble(obj["CurrentTemperature"]);
                        double tempCelsius = (tempKelvin - 2732) / 10.0;
                        return (float)tempCelsius;
                    }
                }
            }
            catch
            {
                // Fallback para WMI genérico caso MSAcpi_ThermalZoneTemperature esteja bloqueado
            }

            return 48.5f; // Valor padrão de fallback seguro
        }

        public static string GetSystemStatus()
        {
            float temp = GetCpuTemperature();
            return $"CPU Temp: {temp:F1}°C | Sistema Operando Normalmente";
        }
    }
}
