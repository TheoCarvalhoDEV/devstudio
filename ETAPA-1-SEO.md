# Etapa 1 — Deixar o site pesquisável

Meta: quando alguém em Mato Grosso digitar "criação de sites" ou "sistema para
empresa" no Google, o DevStudio aparecer. Custo desta etapa: **R$ 0,00**.

> **O texto da página não foi alterado.** Uma primeira versão deste trabalho colocou
> o nome da cidade no título, no hero e nas dúvidas; isso foi desfeito por completo.
> O corpo da página está idêntico ao commit anterior — conferido por comparação
> automática, palavra por palavra. Todo o SEO ficou no `<head>` e em arquivos novos,
> que o visitante não vê.

---

## Parte A — o que já está feito no código

Tudo abaixo já está no repositório. Basta publicar (deploy) para valer.

| Item | O que resolve |
|---|---|
| `<title>` e descrição com "Mato Grosso" | É a linha azul e o textinho cinza que aparecem no Google |
| `<link rel="canonical">` | Diz ao Google qual é o endereço oficial, evita conteúdo duplicado |
| `robots.txt` | Autoriza os robôs e aponta onde está o mapa do site |
| `sitemap.xml` | O mapa do site, que acelera a descoberta pelo Google |
| Dados estruturados `ProfessionalService` | Faz o Google entender que você é um negócio de MT que atende o Brasil |
| Dados estruturados `FAQPage` | Pode fazer suas 7 dúvidas aparecerem direto no resultado da busca |
| `og:image` + Twitter Card (`img/og.png`) | Miniatura decente quando o link é colado no WhatsApp ou Instagram |
| Favicons + `site.webmanifest` | O iconezinho na aba do navegador e na tela do celular |
| Camada de medição em `script.js` | Todo clique no WhatsApp já vira evento — só falta ligar as contas |

**Atenção ao editar:** os dados estruturados repetem, palavra por palavra, o texto
visível da seção "Dúvidas". O Google exige isso. Se um dia você editar uma resposta
no HTML, edite também dentro do bloco `application/ld+json` no `<head>`.

---

## Parte B — o que só você pode fazer

Em ordem de importância. Os três primeiros são bloqueadores.

### 1. Trocar o número do WhatsApp  🚨 BLOQUEADOR

Arquivo [script.js](script.js), primeira linha de código:

```js
const WHATSAPP = "55XXXXXXXXXXX";   // troque por: 55 + DDD + número
```

Exemplo com DDD de Mato Grosso: `"5565999998888"`.

Enquanto estiver com `X`, **nenhum botão do site abre a conversa** — nem o flutuante,
nem a ficha de escopo, nem o formulário. O console do navegador avisa quando está errado.
Ao trocar, o telefone formatado aparece sozinho na seção de contato e entra
automaticamente nos dados estruturados. É um lugar só para editar.

### 2. Resolver a seção "Projetos feitos"  🚨 BLOQUEADOR

Hoje há quatro cartões escritos "Nome do cliente" e "Descreva em duas linhas...".
Isso derruba a confiança de quem chega e o Google trata como página inacabada.

- **Se você tem projetos entregues:** troque as imagens por prints reais, o nome do
  cliente e uma frase sobre o que mudou. As instruções já estão em comentário no HTML,
  logo acima da seção.
- **Se ainda não tem:** apague a `<section id="projetos">` inteira e o link "Projetos"
  do menu. Site sem portfólio converte melhor que site com portfólio de mentira.

### 3. Criar o Perfil da Empresa no Google  ⭐ MAIOR RETORNO DA ETAPA

Vale mais que todo o resto somado. É o que coloca você no mapa e nos primeiros
resultados da busca local — de graça.

Em [google.com/business](https://www.google.com/business/):

1. Nome do negócio: **DevStudio**
2. Categoria principal: **Desenvolvedor de sites**
   (secundárias: *Serviço de design de sites*, *Consultor de software*)
3. Marque **"Atendo clientes no endereço deles"** e defina a área de atendimento
   como **Mato Grosso**, ou como a lista de cidades onde você quer aparecer.
   Assim você não precisa expor endereço nenhum, e o perfil não fica preso a uma
   cidade só.
4. Telefone: o mesmo WhatsApp do site.
5. Site: `https://devstudio.theotheteo.workers.dev/`
6. Horário: seg–sex, 08:00–18:00 (o mesmo que está nos dados estruturados).
7. Envie de 5 a 10 fotos: você trabalhando, prints dos projetos, a tela do computador.
8. A verificação chega por cartão, telefone ou vídeo. Leva de 3 a 14 dias.

**Depois de verificado:** peça avaliação a todo cliente que você já atendeu.
Cinco avaliações com texto colocam você à frente de qualquer concorrente sem perfil.
É o item de maior impacto e menor custo da lista inteira.

### 4. Cadastrar no Google Search Console

Em [search.google.com/search-console](https://search.google.com/search-console):

1. Adicionar propriedade → **Prefixo do URL** → `https://devstudio.theotheteo.workers.dev/`
2. Verificação: escolha **tag HTML**. O Google te dá uma linha assim:
   `<meta name="google-site-verification" content="...">`
   Cole no `<head>` do [index.html](index.html), logo abaixo da `<link rel="canonical">`,
   publique, e clique em Verificar.
3. Menu **Sitemaps** → digite `sitemap.xml` → Enviar.
4. Menu **Inspeção de URL** → cole o endereço do site → **Solicitar indexação**.
   Isso põe o site na fila do Google em vez de esperar ele passar sozinho.

Depois disso é o Search Console que responde "estou aparecendo?" — na aba
**Desempenho** você vê exatamente quais buscas trouxeram gente.

### 5. Cadastrar no Bing Webmaster Tools

[bing.com/webmasters](https://www.bing.com/webmasters) — dá para **importar direto do
Search Console** em dois cliques. Leva um minuto e você ganha o Bing e o Yahoo.

### 6. Trocar os dois placeholders que sobraram

- `img/foto.svg` → sua foto de verdade. Rosto real na seção de contato aumenta
  conversão e é sinal de credibilidade.
- No rodapé, `https://instagram.com/seu_perfil` → seu perfil real, ou apague o link.

### 7. Conferir depois de publicar

| Endereço | Esperado |
|---|---|
| `/robots.txt` | O arquivo do repositório, com a linha `Sitemap:` |
| `/sitemap.xml` | O XML com o endereço do site |
| `/favicon.ico` | O quadradinho azul com o D |
| `/img/og.png` | A imagem de compartilhamento |

⚠️ A Cloudflare serve um `robots.txt` automático em domínios `workers.dev` — foi o que
apareceu quando testei o site agora. Se depois de publicar você abrir `/robots.txt` e
ainda vir aquele texto grande em inglês sobre "content signals", o seu arquivo não está
sendo servido: desative o robots.txt gerenciado no painel da Cloudflare
(*Managed robots.txt* / *AI Crawl Control*).

Por fim, valide os dados estruturados em
[search.google.com/test/rich-results](https://search.google.com/test/rich-results):
devem aparecer **ProfessionalService** e **Perguntas frequentes**, sem erro.

---

## Parte C — sobre o conteúdo (onde esta etapa para)

Vale ser franco sobre o alcance do que foi feito.

Tudo da Parte A é **SEO técnico**: faz o Google entender, indexar e exibir bem o site.
É necessário, e estava faltando por completo. Mas ranquear para um termo disputado
como "criação de sites" depende também de **o termo estar escrito na página** — e o
texto, a seu pedido, ficou exatamente como estava.

O que isso significa na prática:

- Busca pelo seu nome ("devstudio") e Perfil da Empresa no Google: **funciona bem.**
- Busca por "criação de sites em mato grosso": o site vai ser indexado e vai aparecer,
  mas atrás de quem tem o termo escrito no corpo da página.

Se um dia quiser competir por esses termos **sem tocar na landing page**, o caminho é
criar páginas novas e separadas — por exemplo `/criacao-de-sites-mato-grosso` — cada
uma com o seu próprio texto, linkadas discretamente no rodapé. A página principal
continua intacta, e cada página nova disputa um termo. É assim que se faz sem
estragar uma página que já converte.

---

## Parte D — o domínio próprio (para quando puder)

Você optou por manter o `workers.dev` agora, e está tudo montado para funcionar assim.
O que isso custa:

- `workers.dev` é um domínio compartilhado de desenvolvimento da Cloudflare. A
  autoridade que o site construir fica presa a um subdomínio de terceiro.
- Cliente que vê `devstudio.theotheteo.workers.dev` desconfia. Para quem vende site,
  o próprio endereço é a amostra do trabalho.
- Um `.com.br` custa cerca de **R$ 40 por ano** no [registro.br](https://registro.br).

**A migração depois é rápida:** trocar o endereço em 3 arquivos (`index.html` —
canonical, og:url, twitter e os `@id` dos dados estruturados; `robots.txt`;
`sitemap.xml`), apontar o domínio na Cloudflare e usar a ferramenta
**Mudança de endereço** no Search Console. Meia hora de trabalho.

---

## O que esperar, e quando

| Prazo | O que acontece |
|---|---|
| 1 a 3 dias | Google indexa a página (mais rápido se você solicitar indexação) |
| 3 a 14 dias | Perfil da Empresa verificado e aparecendo no mapa |
| 2 a 6 semanas | Começa a aparecer em buscas de cauda longa |
| 2 a 4 meses | Posição estável nos termos onde você tem conteúdo |

SEO é lento no começo e barato depois. É o oposto do anúncio pago, que é imediato e
para de existir no dia em que você desliga. Por isso esta etapa vem primeiro.
