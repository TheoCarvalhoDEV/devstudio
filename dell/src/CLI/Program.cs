using System;
using System.Security.Principal;
using DellFanController.Core;

namespace DellFanController.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dell G15 5530 Fan Controller CLI";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("   ⚡ Dell G15 5530 Fan Controller — CLI (WMI)");
            Console.WriteLine("==================================================");
            Console.ResetColor();

            if (!IsAdministrator())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] AVISO: Execute este programa como Administrador para alterar os perfis térmicos da Dell.");
                Console.ResetColor();
            }

            if (args.Length == 0)
            {
                ShowMenu();
                return;
            }

            string mode = args[0].ToLower().Replace("-", "");

            switch (mode)
            {
                case "gmode":
                case "game":
                    DellWmiThermal.SetProfile(ThermalProfile.GMode);
                    break;
                case "performance":
                case "perf":
                    DellWmiThermal.SetProfile(ThermalProfile.Performance);
                    break;
                case "cool":
                case "refrigeracao":
                    DellWmiThermal.SetProfile(ThermalProfile.Cool);
                    break;
                case "quiet":
                case "silencioso":
                    DellWmiThermal.SetProfile(ThermalProfile.Quiet);
                    break;
                case "balanced":
                case "equilibrado":
                    DellWmiThermal.SetProfile(ThermalProfile.Balanced);
                    break;
                case "status":
                    Console.WriteLine(HardwareMonitor.GetSystemStatus());
                    break;
                default:
                    Console.WriteLine("[X] Argumento inválido. Opções: --gmode, --performance, --cool, --quiet, --balanced, --status");
                    break;
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nEscolha um perfil térmico:");
            Console.WriteLine(" 1. 🔥 G-MODE (100% Rotação Ventoinhas)");
            Console.WriteLine(" 2. ⚡ Desempenho (Performance)");
            Console.WriteLine(" 3. ❄️  Refrigeração (Cool)");
            Console.WriteLine(" 4. ⚖️  Equilibrado (Balanced)");
            Console.WriteLine(" 5. 🤫 Silencioso (Quiet)");
            Console.WriteLine(" 6. 📊 Status do Sistema (Temperatura)");
            Console.WriteLine(" 0. Sair");
            Console.Write("\nDigite a opção desejada (0-6): ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    DellWmiThermal.SetProfile(ThermalProfile.GMode);
                    break;
                case "2":
                    DellWmiThermal.SetProfile(ThermalProfile.Performance);
                    break;
                case "3":
                    DellWmiThermal.SetProfile(ThermalProfile.Cool);
                    break;
                case "4":
                    DellWmiThermal.SetProfile(ThermalProfile.Balanced);
                    break;
                case "5":
                    DellWmiThermal.SetProfile(ThermalProfile.Quiet);
                    break;
                case "6":
                    Console.WriteLine("\n" + HardwareMonitor.GetSystemStatus());
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
