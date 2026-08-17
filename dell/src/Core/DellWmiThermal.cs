using System;
using System.Management;

namespace DellFanController.Core
{
    public enum ThermalProfile
    {
        Quiet = 0x000000A2,
        Balanced = 0x000000A0,
        Cool = 0x000000A1,
        Performance = 0x000000A4,
        GMode = 0x000000AB
    }

    public static class DellWmiThermal
    {
        public static bool SetProfile(ThermalProfile profile)
        {
            uint modeCode = (uint)profile;
            Console.WriteLine($"[*] Aplicando Perfil Dell WMI: {profile} (0x{modeCode:X8})...");

            try
            {
                using (ManagementClass wmiClass = new ManagementClass(@"root\wmi", "Dell_ThermalInformation", null))
                {
                    ManagementBaseObject inParams = wmiClass.GetMethodParameters("SetThermalMode");
                    inParams["ThermalMode"] = modeCode;
                    wmiClass.InvokeMethod("SetThermalMode", inParams, null);
                    Console.WriteLine($"[✓] Perfil {profile} aplicado com sucesso via root\\wmi.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[!] Erro no namespace root\\wmi: {ex.Message}. Tentando root\\dcim\\sysman...");
                try
                {
                    using (ManagementClass sysmanClass = new ManagementClass(@"root\dcim\sysman", "DCIM_ThermalInformation", null))
                    {
                        ManagementBaseObject inParams = sysmanClass.GetMethodParameters("SetThermalMode");
                        inParams["ThermalMode"] = modeCode;
                        sysmanClass.InvokeMethod("SetThermalMode", inParams, null);
                        Console.WriteLine($"[✓] Perfil {profile} aplicado com sucesso via root\\dcim\\sysman.");
                        return true;
                    }
                }
                catch (Exception ex2)
                {
                    Console.WriteLine($"[X] Falha ao definir o perfil térmico: {ex2.Message}");
                    return false;
                }
            }
        }
    }
}
