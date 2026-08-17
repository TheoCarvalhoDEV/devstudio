# ⚡ Dell G15 5530 — Fan & Thermal Controller

Software de controle de ventoinhas, perfis térmicos e ativador do **G-MODE (Game Shift)** projetado especialmente para o notebook **Dell G15 5530** rodando Windows 10/11.

---

## 🎯 Recursos

- **🔥 Modo G-MODE (Game Shift 100%)**: Força todas as ventoinhas (CPU e GPU) no máximo em 1 clique.
- **❄️ Múltiplos Perfis Térmicos**:
  - **Silencioso**: Rotação baixa para ambiente de trabalho e estudo.
  - **Equilibrado**: Ajuste automático recomendado pela Dell.
  - **Refrigeração**: Refrigeração preventiva antes de jogos pesados.
  - **Desempenho**: Desempenho sustentado sem throttling.
  - **G-MODE**: 100% de ventoinha para máxima troca de calor.
- **🖥️ Interface Gráfica (Dark Theme)**: Painel escuro moderno com leitura de temperatura em tempo real.
- **💻 Interface de Linha de Comando (CLI)**: Para automação rápida e integração com atalhos.

---

## 🚀 Como Executar

> ⚠️ **IMPORTANTE**: Como o controle de ventoinhas altera configurações de hardware do BIOS via Dell WMI ACPI, o aplicativo **DEVE ser executado como Administrador**.

### Opção 1: Execução Rápida via Script (Recomendado)

Dê dois cliques no arquivo:
```
dell/scripts/setup.bat
```
O script solicitará permissão de Administrador e abrirá a Interface Gráfica automaticamente.

---

### Opção 2: Via Python (GUI ou CLI)

Abra o terminal como Administrador dentro da pasta `dell/scripts/`:

#### Interface Gráfica (GUI):
```bash
python dell_fan_control.py --gui
```

#### Comandos Rápidos (CLI):
```bash
python dell_fan_control.py --gmode        # Ativa G-MODE (100% ventoinha)
python dell_fan_control.py --performance  # Ativa modo Desempenho
python dell_fan_control.py --quiet        # Ativa modo Silencioso
python dell_fan_control.py --balanced     # Ativa modo Equilibrado
```

---

### Opção 3: Via C# / .NET SDK

Dentro da pasta `dell/`:

```bash
dotnet run -- --gmode
```

---

## ⚙️ Estrutura do Projeto

```
dell/
├── README.md                      # Documentação completa
├── DellFanController.csproj       # Projeto .NET 8
├── scripts/
│   ├── dell_fan_control.py        # Aplicação autônoma Python (GUI + CLI)
│   └── setup.bat                  # Inicializador rápido com elevação Admin
└── src/
    ├── Core/
    │   ├── DellWmiThermal.cs      # Módulo C# de comunicação WMI da Dell
    │   └── HardwareMonitor.cs     # Sensores de temperatura WMI
    └── CLI/
        └── Program.cs             # CLI C# interativo
```

---

## 🔍 Como funciona no firmware da Dell?

O **Dell G15 5530** expõe métodos ACPI na classe WMI `Dell_ThermalInformation` no namespace `root\wmi` ou `root\dcim\sysman`.

Os códigos enviados via método `SetThermalMode` correspondem a:
- `0x000000A0` / `0x000000A3`: **Balanced**
- `0x000000A1`: **Cool**
- `0x000000A2`: **Quiet**
- `0x000000A4`: **Performance**
- `0x000000AB`: **G-Mode (100% Fan Speed)**

---

## 📄 Licença

Desenvolvido para integração no projeto DevStudio. Uso livre.
