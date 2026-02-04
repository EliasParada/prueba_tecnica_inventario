function accionInventario(id, tipo) {
    const cantidad = prompt("Ingrese la cantidad:");

    if (!cantidad || cantidad <= 0) return;

    const url = tipo === "agregar"
        ? "/Inventario/Agregar"
        : "/Inventario/Vender";

    fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            electrodomesticoId: id,
            cantidad: parseInt(cantidad)
        })
    })
        .then(r => {
            if (!r.ok) return r.text().then(t => { throw t });
            return r.json();
        })
        .then(data => {
            document.getElementById("stock-" + id).innerText = data.cantidad;
        })
        .catch(err => {
            alert(err);
        });
}