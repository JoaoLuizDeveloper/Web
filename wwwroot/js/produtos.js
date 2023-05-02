var dataTable;

$(document).ready(function (){
    dataTable = $('#tblData').DataTable({
        responsive: true,
        destroy: true,
        bProcessing: true,
        pageLength: 10,
        lengthMenu: [10, 30, 50, 100],
        "ajax": {
            "url": "/Produtos/GetAll",
            "type": "Get",
            "datatype": "json",
        },
        "columns": [
            { "data": "qtdproduto", "width": "8%" },
            { "data": "nomeProduto", "width": "20%" },
            {
                "data": "precoCusto",
                "render": function (data) {
                    return `R$ ${data}`
                }, "width": "8%"
            },
            {
                "data": "precoVenda",
                "render": function (data) {
                    return `R$ ${data}`
                }, "width": "8%"
            },
            {
                "data": "subTotal",
                "render": function (data, type, full, meta) {
                    return `<div class="text-center" >
                                <div class='btn text-black renda' style="cursor:pointer; width: 160px; border-radius: 10px; background-color:gray;">
                                    R$ ${(full.precoVenda * full.qtdproduto).toString().substring(0, 5)}
                                </div>
                            </div>`
                }, "width": "10%"
            },
            {
                "data": "id",
                "render": function (data, type, full, meta) {
                    //Use `` for multiple lines
                    if (full.produtoTipo == 2) {
                        return `
                            <div class="text-center">
                                <a href="/Produtos/Editar/${data}" class='btn btn-warning text-white' style="cursor:pointer; width: 90px">
                                    <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;

                                <a onclick=Delete("/Produtos/Delete/${data}") class='btn btn-danger text-white' style="cursor:pointer; width: 100px">
                                    <i class="far fa-trash-alt"></i> Deletar
                                </a>
                            </div>
                            `
                    } else {
                        return `
                            <div class="text-center">
                                <a href="/Produtos/Editar/${data}" class='btn btn-warning text-white' style="cursor:pointer; width: 90px">
                                    <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;

                                <a onclick=Delete("/Produtos/Delete/${data}") class='btn btn-danger text-white' style="cursor:pointer; width: 100px">
                                    <i class="far fa-trash-alt"></i> Deletar
                                </a>
                            </div>
                            `
                    }
                    
                }, "width": "48%"
            }
        ],
        "language": {
            "lengthMenu": "Mostrando _MENU_ entradas",
            "emptyTable": "Sem Dados encotrados.",
            "zeroRecords": "Sem Dados encontrados",
            "info": "Mostrando Pagina _PAGE_ de _PAGES_",
            "infoEmpty": "Encontrados 0 ",
            "infoFiltered": "",
            "search": "Procurar",
            "paginate": {
                "previous": "Pagina Anterior",
                "next": "Proxima Pagina",
                "first": "Primeira Pagina"
            }
        },
        "width": "100%"
    });

    var model = [];
});

function Delete(url) {
    swal({
        title: "Você tem certeza que quer deletar?",
        text: "Voce não será capaz de restaurar o Produto!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmbuttonText: "Sim, delete!",
        closeOnconfirm: true
    }, function () {
            $.ajax({
                type: 'Delete',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
    });
}