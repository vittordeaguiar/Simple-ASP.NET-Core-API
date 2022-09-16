async function PessoaListaPessoas() {
    return new Promise((resolve, reject) => {
        Get('Pessoa/ListaPessoas').then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Pessoa/BuscaPorId').then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaBuscaPorNome(nome) {
    return new Promise((resolve, reject) => {
        Get('Pessoa/BuscaPorNome').then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaBuscaPorCpf(cpf) {
    return new Promise((resolve, reject) => {
        Get('Pessoa/BuscaPorCpf').then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}


async function PessoaSalvar(obj) {
    return new Promise((resolve, reject) => {
        Post('Pessoa/Salvar', obj).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function CidadeRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Cidade/Remover?id=' + id).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}