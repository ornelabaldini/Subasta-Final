# Sistema de Subastas – WinForms (.NET 8)

## 📌 Descripción del proyecto
Este proyecto consiste en el desarrollo de una **aplicación de escritorio en C# utilizando WinForms y .NET 8**, cuyo objetivo es modelar y administrar un **Sistema de Subastas**, permitiendo gestionar múltiples subastas en simultáneo.

El sistema fue diseñado siguiendo una **arquitectura en capas (MVC)**, aplicando los principios fundamentales de la **Programación Orientada a Objetos**, con validaciones de modelo, modularidad y reutilización de código.

---

## 🧾 Enunciado
Se desea modelar un sistema que pueda administrar más de una subasta al mismo tiempo.  
Una subasta se crea con:
- Nombre del subastador
- Artículo
- Puja inicial (precio base)
- Incremento mínimo (puja)
- Fecha y horario de inicio
- Duración total en minutos

Durante el transcurso de la subasta es posible el ingreso o egreso de postores.  
Cada postor posee un **número único** que lo identifica y puede participar en **más de una subasta al mismo tiempo**.

Una subasta finaliza automáticamente al cumplirse el tiempo establecido, aun cuando no haya ofertas.  
Al finalizar, el sistema determina:
- El ganador de la subasta (si existe)
- El monto a abonar
- La diferencia entre la puja inicial y la oferta ganadora

---

## 🎯 Objetivos del sistema
- Administrar múltiples subastas simultáneas
- Permitir el acceso al sistema como **Postor** o **Subastador**
- Gestionar pujas respetando las reglas de negocio
- Aplicar arquitectura en capas y buenas prácticas de diseño
- Cumplir con los criterios de aprobación de la cursada

---

## 🧱 Arquitectura del proyecto
El sistema está organizado en un **modelo de capas**, de acuerdo con los criterios solicitados:

- **Entities**  
  Contiene las clases del dominio:
  - Subasta
  - Postor
  - Subastador
  - Artículo
  - Puja

- **Views**  
  Formularios WinForms que representan la interfaz gráfica del sistema:
  - Inicio
  - Registro de Postor
  - Registro de Subastador
  - Vista de Postor
  - Vista de Subastador

- **Controllers**  
  Coordinan la interacción entre las vistas y la lógica de negocio.

- **Services**  
  Implementan las reglas de negocio del sistema.

- **Repositories**  
  Administran el acceso y manejo de datos (persistencia).

- **Interfaces**  
  Definen contratos para servicios y repositorios, favoreciendo la reutilización y desacoplamiento.

---

## ⚙️ Funcionalidades implementadas

### Requerimientos para aprobación de cursada
- Acceso al sistema como **Postor** o **Subastador**
- Vista de todas las subastas con su detalle
- CRUD de Postor
- CRUD de Subastador
- CRUD de Subasta
- Ingreso de un postor a una subasta
- Al menos una vista funcional

### Requerimientos adicionales para promoción
- Pujar sobre una subasta como postor
- Inicio automático de subasta
- Finalización automática de subasta
- Determinación automática del ganador
- Conexión con base de datos

---

## 🧠 Conceptos aplicados
- Programación Orientada a Objetos
- Encapsulamiento, herencia y polimorfismo
- Validaciones de modelo
- Separación de responsabilidades
- Arquitectura MVC en WinForms
- Modularidad y reutilización de código

---

## 🛠️ Tecnologías utilizadas
- **Lenguaje:** C#
- **Framework:** .NET 8
- **Interfaz gráfica:** Windows Forms
- **Arquitectura:** MVC (Modelo en capas)
- **Control de versiones:** Git y GitHub

---

