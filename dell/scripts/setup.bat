@echo off
title Dell G15 5530 Fan Controller — Setup & Execucao
cls

echo =======================================================
echo    ⚡ Dell G15 5530 Fan Controller — Inicializador
echo =======================================================
echo.

:: Verificar privilégios de Administrador
net session >nul 2>&1
if %errorLevel% neq 0 (
    echo [!] AVISO: Solicitando privilégios de Administrador...
    powershell -Command "Start-Process '%~0' -Verb RunAs"
    exit /b
)

echo [1/2] Executando verificacao de ambiente Python...
where python >nul 2>&1
if %errorLevel% equ 0 (
    echo [✓] Python detectado! Iniciando Interface Grafica (dell_fan_control.py)...
    start "" python "%~dp0dell_fan_control.py" --gui
    goto end
)

echo [2/2] Python nao encontrado no PATH. Tentando compilar versao C# .NET...
where dotnet >nul 2>&1
if %errorLevel% equ 0 (
    echo [✓] .NET SDK detectado! Compilando projeto...
    cd /d "%~dp0.."
    dotnet run
    goto end
)

echo [X] Erro: Nem Python nem .NET SDK foram encontrados no seu computador.
echo Por favor, instale o Python 3 ou o .NET 8 SDK para rodar a aplicacao.
pause

:end
