# ubigen‑cli

> **Domain‑first microservice generator CLI for .NET** – scaffold production‑ready micro‑services from a single `service.yaml` definition and a reusable starter template.

---

## ✨ Why ubigen‑cli?

* **Opinionated but flexible** – service boundaries, adapters and bounded‑contexts are declared once in YAML; CLI turns them into clean, test‑ready code.
* **Zero‑friction bootstrap** – grab a starter repo, rename, restore, run. That’s it.
* **Open‑source & extendable** – CLI (C#), Core model library, and Starter template live in separate repos. Fork and tweak anything.
* **Agent‑friendly** – metadata (health endpoints, adapters) is ready for MCP / AI agents to orchestrate.

---

## 🔰 Prerequisites

| Tool         | Version          |
| ------------ | ---------------- |
| **.NET SDK** | **9.0** or newer |
| **Git**      | any recent       |

---

## 🚀 Getting Started (Local Development)

```bash
# 1️⃣ Clone the CLI repository
$ git clone git@github.com:ubigen/ubigen-cli.git
$ cd ubigen-cli

# 2️⃣ Restore, build, test
$ dotnet build
$ dotnet test

# 3️⃣ Pack the global tool locally
$ dotnet pack src/Ubigen.Cli -c Release

# 4️⃣ Install the freshly‑built tool (local source)
$ dotnet tool install --global ubigen \
      --add-source src/Ubigen.Cli/bin/Release \
      --ignore-failed-sources

# 5️⃣ Verify installation
$ ubigen hello --name "World"
👋 Hello, World! ubigen is ready.
```

### Bootstrap a New Service

```bash
# 1. Create service from starter template (pulled from ubigen‑starter repo)
$ ubigen init-service NotificationService \
      -d "Sends e‑mail, SMS and push notifications"

# 2. Jump inside the generated folder
$ cd NotificationService

# 3. Run the API (Kestrel)
$ dotnet run --project src/NotificationService.Api
```

---

## 🔧 Core Commands

| Command                                       | Purpose                                                                      |
| --------------------------------------------- | ---------------------------------------------------------------------------- |
| `ubigen hello --name <name>`                  | Quick sanity‑check that the CLI is installed                                 |
| `ubigen init-service <name>`                  | Download starter → create `<name>` folder → write `service.yaml`             |
| `ubigen add-adapter <key>`                    | Register a predefined adapter (`messaging`, `database`, …) in `service.yaml` |
| `ubigen add-context <ctx>` *(coming soon)*    | Create `contexts/<ctx>.yaml` + feature folders                               |
| `ubigen add-entity / add-command` *(roadmap)* | Extend context YAML and drop code stubs                                      |

> **TIP** Run `ubigen --help` for the full command list.

---

## 🗂 Repository Layout (CLI repo)

```
ubigen-cli/
├── src/
│   ├── Ubigen.Cli/      # Spectre.Console‑powered global tool
│   ├── Ubigen.Core/     # Models + YAML parser (can be reused elsewhere)
│   └── Ubigen.Test/     # xUnit tests for Core
└── Ubigen.sln           # Solution file (CLI only)
```

The **starter template** lives in a **separate** repository:

```
https://github.com/ubigen/ubigen-starter
```

`init-service` downloads it as `main.zip`, renames all `UbiTemplate` placeholders and restores dependencies.

---

## 🛠  Development Workflow

1. **Design** – edit `service.yaml` (service meta) and individual `contexts/*.yaml` files.
2. **Generate** – use `ubigen add-*` commands to scaffold folders & stubs.
3. **Implement** – fill in business logic, add tests.
4. **Iterate** – adjust YAML, re‑run CLI commands, keep code & spec in sync.

---

## 🤝 Contributing

1. **Fork** the repo & clone your fork.
2. `git checkout -b feat/my-awesome-feature`
3. Implement + **add unit tests**.
4. `git commit -s -m "feat: explain what you did"`
5. `git push && open PR` – we’ll review ASAP!

---

## 📬 Contact

* **Email:** [umitcivi@gmail.com](mailto:umitcivi@gmail.com)
* **WhatsApp:** [+90 542 440 96 12](https://wa.me/905424409612)

Feel free to reach out—feedback and feature requests are welcome.

---

## 📄 License

Released under the **MIT License**. See [LICENSE](LICENSE) for details.
