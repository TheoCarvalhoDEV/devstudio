# Etapa 2 — Tráfego pago (Google Ads, só rede de pesquisa)

Está tudo montado aqui, pronto para copiar e colar. **Não ligue ainda.**
Leia o aviso abaixo primeiro — ele muda a decisão.

---

## Antes de gastar o primeiro real

Você definiu R$ 100 por mês. Isso são **R$ 3,33 por dia**.
Em Mato Grosso, o clique em termos de "criação de sites" custa entre R$ 3 e R$ 8.
Ou seja: entre **12 e 30 cliques no mês inteiro**. Com uma taxa de conversão boa
(uns 10%), dá 1 a 3 conversas no WhatsApp por mês.

Não é impossível — é apertado. O que decide se vale a pena não é o orçamento,
é o **volume de busca** na região que você escolher. Por isso o passo 1 abaixo
é gratuito e vem antes de qualquer gasto.

**A ordem certa é a que você já escolheu:**

1. **Agora:** Perfil da Empresa no Google + SEO (Etapa 1). Custo zero, e captura
   exatamente as mesmas pessoas que o anúncio captaria.
2. **Antes de ligar:** teste de volume no Planejador de palavras-chave (passo 1).
3. **Só depois:** ligue a campanha, com a estrutura pronta que está aqui.

Se o teste mostrar volume baixo, a resposta certa não é gastar mais — é concentrar
o anúncio em Cuiabá e Várzea Grande (onde está o volume do estado) ou guardar o
dinheiro e investir em avaliações no Perfil da Empresa, que rendem mais por real gasto.

---

## Passo 1 — Descobrir se existe busca (grátis, 15 minutos)

1. Crie a conta em [ads.google.com](https://ads.google.com). **Não crie campanha ainda** —
   se ele empurrar o modo simplificado ("Smart"), procure o link
   *"Alternar para o modo especialista"* embaixo. Isso é importante: no modo
   simplificado você não controla nada e o dinheiro some.
2. Menu **Ferramentas → Planejamento → Planejador de palavras-chave**.
3. **Descobrir novas palavras-chave** → digite: `criação de sites`,
   `criar site para empresa`, `desenvolvedor de sites`, `sistema para empresa`.
4. No topo, mude a localização para **Mato Grosso** e o idioma para português.
5. Olhe a coluna **"Média de pesquisas mensais"**.

**Como ler o resultado:**

| Resultado | O que fazer |
|---|---|
| Termos com 50+ buscas/mês no estado | Vale ligar. Siga para o passo 2. |
| Volume só aparece em Cuiabá / Várzea Grande | Ligue, mas segmente só essas cidades |
| Quase tudo "0 – 10" em todo lugar | Não ligue anúncio. Foque no Perfil da Empresa e em indicação |

Repita o teste trocando a localização para **Cuiabá** e depois para **Brasil**.
Comparar os três números mostra na hora onde o seu R$ 100 tem chance.

---

## Passo 2 — Ligar a medição no site (antes da campanha)

Sem isto você paga por cliques e **nunca fica sabendo quais viraram conversa**.
Nunca ligue campanha sem esta parte pronta.

### 2.1 — Google Analytics 4

1. Crie a propriedade em [analytics.google.com](https://analytics.google.com).
2. Copie o **ID de medição**, no formato `G-XXXXXXXXXX`.
3. Cole no [index.html](index.html), no bloco `window.MEDICAO` no fim do `<head>`:

```js
window.MEDICAO = {
    ga4: "G-XXXXXXXXXX",
    ads: "",
    adsLabel: ""
};
```

### 2.2 — Conversão do Google Ads

1. No Google Ads: **Metas → Conversões → Nova ação de conversão → Site**.
2. Nome: `Clique no WhatsApp`. Categoria: **Contato**. Valor: pode deixar sem valor.
3. Escolha **"Adicionar a tag manualmente"**. O Google mostra duas coisas:
   - **ID da conversão**, formato `AW-123456789`
   - **Rótulo da conversão**, formato `AbC-D_efGhIjK`
4. Cole os dois no mesmo bloco:

```js
window.MEDICAO = {
    ga4: "G-XXXXXXXXXX",
    ads: "AW-123456789",
    adsLabel: "AbC-D_efGhIjK"
};
```

Pronto. O `script.js` cuida do resto: carrega as tags sozinho e dispara a conversão
em **todo** clique que leva ao WhatsApp — botão do topo, botão flutuante, ficha de
escopo e formulário. Cada conversão vem etiquetada com a origem
(`hero`, `servicos`, `orcamento`, `ficha_de_escopo`, `formulario_de_contato`,
`flutuante`), então você descobre qual pedaço da página realmente vende.

**Enquanto os campos estiverem vazios, nada é carregado e nada quebra** — o site não
faz nenhuma chamada ao Google e continua leve.

### 2.3 — Conferir que funciona

Publique, abra o site, clique num botão de WhatsApp. No Google Analytics, em
**Relatórios → Tempo real**, o evento `clique_whatsapp` tem que aparecer em segundos.
Se não aparecer, os códigos estão errados ou o deploy não subiu.

---

## Passo 3 — A campanha (copiar e colar)

### Configuração

| Campo | Valor | Por quê |
|---|---|---|
| Tipo | **Pesquisa** | Só quem está procurando. Nada de Display ou Vídeo. |
| Objetivo | **Criar campanha sem orientação de meta** | Evita o Google escolher por você |
| Redes | Desmarque **Rede de Display** e **Parceiros de pesquisa** | Sozinhas, comem metade do orçamento com clique ruim |
| Orçamento diário | **R$ 3,33** | O Google pode gastar até o dobro num dia, mas nunca passa de R$ 100 no mês |
| Lances | **Maximizar cliques** com **limite de CPC de R$ 3,00** | Sem o limite, um clique come 3 dias de orçamento |
| Local | **Mato Grosso** — ou só Cuiabá + Várzea Grande, se o passo 1 apontou para lá | |
| Opções de local | **"Presença: pessoas que estão ou frequentam"** | O padrão inclui quem só *pesquisou sobre* o lugar. Sempre troque. |
| Idioma | Português | |
| Horário | Seg–Sex, 08:00 às 19:00 | Você não responde às 3 da manhã; não pague por clique nesse horário |
| Dispositivos | Todos, sem ajuste | A maior parte vem de celular, e o site é feito para celular |

### Palavras-chave (correspondência de **frase**, entre aspas)

Cole exatamente assim, com as aspas — são elas que impedem o Google de inventar buscas:

```
"criação de sites mato grosso"
"criação de sites cuiabá"
"criar site para empresa"
"fazer site para empresa"
"desenvolvedor de sites mt"
"empresa de criação de sites"
"criação de site para loja"
"landing page para anúncio"
"página de vendas profissional"
"sistema para pequena empresa"
"sistema para controlar pedidos"
"sistema web sob medida"
"site com pagamento pix"
"automação de cobrança"
```

### Palavras-chave negativas (obrigatório)

Sem esta lista você paga para estudante e curioso. Cole tudo de uma vez em
**Palavras-chave → Negativas**:

```
grátis
gratis
gratuito
de graça
curso
cursos
aula
apostila
tutorial
como fazer
como criar
passo a passo
emprego
vaga
vagas
salário
estágio
freelancer
template
modelo pronto
download
baixar
wix
wordpress
hostinger
webnode
canva
você mesmo
sozinho
pdf
significado
o que é
```

### Anúncio responsivo de pesquisa

**Títulos** (máx. 30 caracteres cada — cole todos, o Google testa as combinações):

```
Criação de Sites em MT
Sites e Sistemas Sob Medida
Site Pronto em 7 a 12 Dias
Orçamento Fechado Antes
Fale Direto com Quem Faz
Sem Vendedor no Meio
Site para a Sua Empresa
Sistema no Lugar da Planilha
Orçamento pelo WhatsApp
Sem Mensalidade Escondida
O Site Fica no Seu Nome
Página de Vendas Que Vende
```

**Descrições** (máx. 90 caracteres cada):

```
Você conta o problema com as suas palavras. Recebe o valor e o prazo antes de começar.
Páginas de vendas, sistemas para equipe e cobrança automática por PIX e cartão.
Você fala direto com quem escreve o código. Resposta em até 1 hora no WhatsApp.
Domínio, hospedagem e arquivos no seu nome. 30 dias de suporte inclusos.
```

**URL final:** `https://devstudio.theotheteo.workers.dev/`
**Caminho de exibição:** `/criacao-de-sites` e `/orcamento`

> Fixe o título "Criação de Sites em MT" na **posição 1** se você segmentou o estado.
> Anúncio que mostra a região tem clique mais barato que anúncio genérico.

### Recursos (as antigas "extensões") — gratuitos e aumentam o clique

**Links de site** (título até 25, duas linhas de até 35):

| Título | Linha 1 | Linha 2 | Vai para |
|---|---|---|---|
| Como funciona | Quatro etapas, do primeiro oi | até o site entrar no ar | `/#passos` |
| Serviços e prazos | Página de vendas, sistema | e automação de cobrança | `/#servicos` |
| Montar orçamento | Marque o que precisa e receba | o valor no WhatsApp | `/#orcamento` |
| Dúvidas frequentes | Preço, prazo, pagamento e | o que acontece após entregar | `/#duvidas` |

**Frases de destaque** (até 25 caracteres):

```
Valor fechado antes
Entrega em 7 a 12 dias
O site fica no seu nome
Sem contrato de fidelidade
Resposta em até 1 hora
30 dias de suporte
Atendimento em todo o BR
```

**Snippet estruturado** → cabeçalho **Serviços**:
`Página de vendas`, `Sistema para equipe`, `Automação de cobrança`,
`Pagamento PIX e cartão`, `Manutenção de site`

**Chamada:** seu número de WhatsApp, ativo só de seg–sex 08:00–18:00.

**Local:** vincule o Perfil da Empresa do Google (o da Etapa 1). Isso põe a região
embaixo do anúncio e é o que mais aumenta o clique em busca local.

---

## Passo 4 — Como acompanhar sem se enganar

**Nas duas primeiras semanas, não mexa em nada.** Toda campanha nova passa por um
período de aprendizado, e mexer todo dia reinicia esse período. Com R$ 3,33/dia o
volume é tão baixo que qualquer conclusão antes de 30 dias é chute.

**Uma vez por semana, olhe só isto:**

1. **Relatório de termos de pesquisa** — o que a pessoa digitou de verdade, não a sua
   palavra-chave. Tudo que não for gente querendo contratar, jogue nas negativas.
   Nesse orçamento, é a única otimização que importa.
2. **Conversões.** Se depois de 30 dias houver zero conversão com 20+ cliques, o
   problema é a página ou o atendimento, não o anúncio.
3. **CPC médio.** Se passou de R$ 5, aperte o limite de lance ou corte palavras.

**Depois de 30 dias, decida:**

| Situação | Decisão |
|---|---|
| Conversas chegaram e viraram orçamento | Suba para R$ 200–300/mês, mesma estrutura |
| Cliques vieram, conversa não | Pare. O problema é a página ou o número não estar respondendo |
| Nem cliques vieram (poucas impressões) | Não há busca suficiente. Desligue e volte tudo para o Perfil da Empresa |

---

## O que **não** fazer

- **Não** ative Performance Max, Display, YouTube ou "Demanda". Com R$ 100 eles
  gastam tudo em impressão barata e sem intenção. Você pediu foco em pesquisa —
  mantenha só pesquisa.
- **Não** use correspondência ampla (palavra sem aspas). Com orçamento pequeno é a
  forma mais rápida de queimar o mês em cliques irrelevantes.
- **Não** aceite as "recomendações" automáticas do Google sem ler. A maioria amplia
  gasto. Desligue a aplicação automática em *Recomendações → Aplicação automática*.
- **Não** mande todo anúncio para o topo do site. Cada link de site desta lista já
  leva à seção certa — quem clica em "Dúvidas" cai nas dúvidas.
- **Não** ligue a campanha antes de trocar o número do WhatsApp no `script.js`.
  Você estaria pagando por cliques em botões quebrados.

---

## Resumo da ordem

```
[ ] Trocar WHATSAPP no script.js          <- sem isso, nada mais importa
[ ] Resolver a seção "Projetos feitos"
[ ] Criar e verificar o Perfil da Empresa no Google
[ ] Search Console + sitemap + solicitar indexação
[ ] Pedir 5 avaliações a clientes antigos
    ---------- esperar 30 dias e ver o que chegou de graça ----------
[ ] Teste de volume no Planejador de palavras-chave
[ ] Ligar GA4 + conversão do Ads no window.MEDICAO
[ ] Conferir o evento clique_whatsapp no Tempo real
[ ] Só então: ligar a campanha com R$ 3,33/dia
```
