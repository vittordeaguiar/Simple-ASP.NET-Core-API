function salvar() {
    let obj = {
        cep: ($("[name='cep']").val() || ''),
        nome: ($("[name='nome']").val() || ''),
        estado: ($("[name='estado']").val() || '')
    };
    CidadeSalvar(obj).then(function () {
        window.location.href = '/cidades';
    }, function (err) {
        alert(err);
    });
}