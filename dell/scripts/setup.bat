@echo off
chcp 65001 >nul
title Dell G15 5530 Fan Controller — Setup & Execucao
cls

echo =======================================================
echo    ⚡ Dell G15 5530 Fan Controller — Inicializador
echo =======================================================
echo.

REM Verificar privilégios de Administrador
net session >nul 2>&1
if %errorLevel% neq 0 (
    echo [!] Solicitando privilégios de Administrador...
    powershell -Command "Start-Process cmd.exe -ArgumentList '/c \"\"%~f0\"\"' -Verb RunAs"
    exit /b
)

cd /d "%~dp0"

echo [1/2] Executando verificação de ambiente Python...
where python >nul 2>&1
if %errorLevel% equ 0 (
    echo [✓] Python detectado! Iniciando Interface Gráfica...
    python "%~dp0dell_fan_control.py" --gui
    if %errorLevel% neq 0 (
        echo [X] Ocorreu um erro ao executar a interface gráfica.
        pause
    )
    goto end
)

echo [2/2] Python não encontrado no PATH. Tentando compilar versão C# .NET...
where dotnet >nul 2>&1
if %errorLevel% equ 0 (
    echo [✓] .NET SDK detectado! Compilando projeto...
    cd /d "%~dp0.."
    dotnet run
    if %errorLevel% neq 0 (
        echo [X] Erro ao compilar com o .NET SDK.
        pause
    )
    goto end
)

echo [X] Erro: Nem Python nem .NET SDK foram encontrados no seu computador.
echo Por favor, instale o Python 3 ou o .NET 8 SDK para rodar a aplicação.
pause

:end
