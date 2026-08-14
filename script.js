/* DevStudio — comportamento da página */

// Troque aqui e vale para o site inteiro (formato: 55 + DDD + número).
const WHATSAPP = "55XXXXXXXXXXX";

const wa = (msg) => `https://wa.me/${WHATSAPP}?text=${encodeURIComponent(msg)}`;

document.addEventListener("DOMContentLoaded", () => {
    linkWhatsApp();
    initMenu();
    initScope();
    initForm();
    initTechFilter();
    initReveal();
    initHeader();
    document.getElementById("year").textContent = new Date().getFullYear();
});

/* Todo link com data-wa recebe o número configurado acima */
function linkWhatsApp() {
    document.querySelectorAll("[data-wa]").forEach(el => {
        el.href = wa(el.dataset.wa);
        el.target = "_blank";
        el.rel = "noopener noreferrer";
    });
}

function initMenu() {
    const btn = document.getElementById("menu-toggle");
    const nav = document.getElementById("mobile-nav");

    btn.addEventListener("click", () => {
        const open = nav.classList.toggle("is-open");
        btn.setAttribute("aria-expanded", String(open));
        btn.textContent = open ? "Fechar" : "Menu";
    });

    nav.querySelectorAll("a").forEach(a => a.addEventListener("click", () => {
        nav.classList.remove("is-open");
        btn.setAttribute("aria-expanded", "false");
        btn.textContent = "Menu";
    }));
}

/* Ficha de escopo */
function initScope() {
    const types = document.querySelectorAll("#project-type-group .type-btn");
    const extras = document.querySelectorAll(".calc-extra");
    const outType = document.getElementById("summary-type");
    const outTime = document.getElementById("summary-time");
    const outCount = document.getElementById("summary-count");
    const outExtras = document.getElementById("summary-extras");
    const send = document.getElementById("send-calculator-wa");

    let type = "Página de vendas";
    let time = "7 a 12 dias";

    types.forEach(btn => btn.addEventListener("click", () => {
        types.forEach(b => b.setAttribute("aria-pressed", "false"));
        btn.setAttribute("aria-pressed", "true");
        type = btn.dataset.val;
        time = btn.dataset.time;
        update();
    }));

    extras.forEach(cb => cb.addEventListener("change", update));

    function update() {
        const chosen = [...extras].filter(cb => cb.checked).map(cb => cb.value);

        outType.textContent = type;
        outTime.textContent = time;
        outCount.textContent = chosen.length;
        outExtras.innerHTML = chosen.length
            ? chosen.map(e => `<li>${e}</li>`).join("")
            : `<li>Nenhum item adicional</li>`;

        send.href = wa(
            `*Ficha de escopo — DevStudio*\n\n` +
            `Tipo: ${type}\n` +
            `Prazo estimado: ${time}\n` +
            `Itens: ${chosen.length ? chosen.join(", ") : "nenhum"}\n\n` +
            `Montei essa ficha no site. Quanto fica?`
        );
        send.target = "_blank";
        send.rel = "noopener noreferrer";
    }

    update();
}

function initForm() {
    const form = document.getElementById("contact-form");

    form.addEventListener("submit", e => {
        e.preventDefault();
        const name = document.getElementById("form-name").value.trim();
        const service = document.getElementById("form-service").value;
        const msg = document.getElementById("form-msg").value.trim();

        window.open(wa(
            `*Contato pelo site — DevStudio*\n\n` +
            `Nome: ${name}\n` +
            `Precisa de: ${service}` +
            (msg ? `\nDetalhes: ${msg}` : "")
        ), "_blank", "noopener");
    });
}

function initTechFilter() {
    const grid = document.getElementById("tech-grid");
    const tabs = document.querySelectorAll(".tab");
    const items = document.querySelectorAll(".stack-item");

    tabs.forEach(tab => tab.addEventListener("click", () => {
        tabs.forEach(t => t.setAttribute("aria-selected", "false"));
        tab.setAttribute("aria-selected", "true");

        const cat = tab.dataset.category;
        items.forEach(item => {
            item.hidden = cat !== "all" && item.dataset.category !== cat;
        });

        // reinicia a animação de entrada: tirar a classe e ler offsetWidth
        // força o navegador a recalcular antes de recolocá-la.
        grid.classList.remove("is-swap");
        void grid.offsetWidth;
        grid.classList.add("is-swap");
    }));
}

/* Elementos entram conforme a página rola, uma vez só */
function initReveal() {
    const items = document.querySelectorAll(".reveal");

    const observer = new IntersectionObserver((entries, obs) => {
        entries.forEach(entry => {
            if (!entry.isIntersecting) return;
            entry.target.classList.add("is-in");
            obs.unobserve(entry.target);
        });
    }, { threshold: 0.12, rootMargin: "0px 0px -40px 0px" });

    items.forEach(el => {
        // vizinhos do mesmo grupo entram em cascata
        const group = [...el.parentElement.children].filter(n => n.classList.contains("reveal"));
        el.style.setProperty("--d", `${Math.min(group.indexOf(el), 3) * 90}ms`);
        observer.observe(el);
    });
}

/* Sombra no cabeçalho depois que a página sai do topo */
function initHeader() {
    const header = document.querySelector(".site-header");
    if (!header) return;
    const onScroll = () => header.classList.toggle("is-stuck", window.scrollY > 8);

    onScroll();
    window.addEventListener("scroll", onScroll, { passive: true });
}

