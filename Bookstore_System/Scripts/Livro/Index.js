var _id_livro;

angular.module('app', []).controller('controller',
    function ($scope, $http) {

        var scope = $scope;

        $scope.ListaLivros = function () {

            $http.get("../Livro/RetornaLivros").then(function (response) {
                $scope.livros = response.data;

                for (var i = 0; i < $scope.livros.length; i++) {
                    var date = $scope.livros[i].data_lancamento.split("T")[0];

                    $scope.livros[i].data_lancamento = date.split("-")[2] + "/" + date.split("-")[1] + "/" + date.split("-")[0]
                }
            });

        }

        $scope.ListaLivros();

        $scope.AdicionaLivro = function () {
            var _nome = $("#nome").val(), _autor = $("#autor").val(), _editora = $("#editora").val(), _data_lancamento = $("#data_lancamento").val();

            if (VerificaCampos(_nome, _autor, _editora, _data_lancamento)) {
                complete_ajax_with_parameters_without_success("POST", "../Livro/AdicionaLivro", "application/json;charset=utf-8",
                    JSON.stringify({ nome: _nome, autor: _autor, editora: _editora, data_lancamento: _data_lancamento })).done(function (response) {

                        var mensagem = JSON.parse(response);

                        if (mensagem) {

                            $("#modal_adicionar").modal("hide");

                            if (mensagem.Codigo == 200) {
                                scope.ListaLivros();
                                renderSuccessAlert(mensagem.Texto);
                            }
                            else {
                                renderErrorAlert(mensagem.Texto);
                            }
                        }

                    });
            }
            else {
                renderErrorAlert("Não é permitido campos vazios.")
            }
        }

        $scope.CarregaModalEditar = function () {

            _id_livro = this.livro.id;

            $("#nome_editar").val(this.livro.nome);
            $("#autor_editar").val(this.livro.autor);
            $("#editora_editar").val(this.livro.editora);
            $("#data_lancamento_editar").val(this.livro.data_lancamento);
        };

        $scope.EditaLivro = function () {
            var _nome = $("#nome_editar").val(), _autor = $("#autor_editar").val(), _editora = $("#editora_editar").val(), _data_lancamento = $("#data_lancamento_editar").val();

            if (VerificaCampos(_nome, _autor, _editora, _data_lancamento)) {
                complete_ajax_with_parameters_without_success("POST", "../Livro/EditaLivro", "application/json;charset=utf-8",
                    JSON.stringify({ id_livro: _id_livro, nome: _nome, autor: _autor, editora: _editora, data_lancamento: _data_lancamento })).done(function (response) {

                        var mensagem = JSON.parse(response);

                        if (mensagem) {

                            $("#modal_editar").modal("hide");

                            if (mensagem.Codigo == 200) {
                                scope.ListaLivros();
                                renderSuccessAlert(mensagem.Texto);
                            }
                            else {
                                renderErrorAlert(mensagem.Texto);
                            }
                        }

                    });
            }
            else {
                renderErrorAlert("Não é permitido campos vazios.")
            }
        };

        $scope.RemoveLivro = function () {


            complete_ajax_with_parameters_without_success("POST", "../Livro/RemoveLivro", "application/json;charset=utf-8",
                JSON.stringify({ id_livro: this.livro.id })).done(function (response) {

                    var mensagem = JSON.parse(response);

                    if (mensagem) {
                        if (mensagem.Codigo == 200) {
                            scope.ListaLivros();
                            renderSuccessAlert(mensagem.Texto);
                        }
                        else {
                            renderErrorAlert(mensagem.Texto);
                        }
                    }

                });
        }

    });

function VerificaCampos(nome, autor, editora, data_lancamento) {
    return nome && autor && editora && data_lancamento;
}
