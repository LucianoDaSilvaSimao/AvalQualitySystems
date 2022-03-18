using System;

namespace WS.CRUD
{
    public class PdvEstacaoCategoriaProduto : WS.CRUD.Base
    {
        public PdvEstacaoCategoriaProduto(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacaoCategoriaProduto input = (Data.PdvEstacaoCategoriaProduto)parametros["Key"];
            Tables.PdvEstacaoCategoriaProduto bd = new Tables.PdvEstacaoCategoriaProduto();

            if (input.produtoServico != null)
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else { }

            if (input.pdvEstacaoCategoria != null)
                bd.pdvEstacaoCategoria.idPdvEstacaoCategoria.value = input.pdvEstacaoCategoria.idPdvEstacaoCategoria;
            else { }

            bd.ordem.value = input.ordem;

            this.m_EntityManager.persist(bd);
            ((Data.PdvEstacaoCategoriaProduto)parametros["Key"]).idPdvEstacaoCategoriaProduto = (int)bd.idPdvEstacaoCategoriaProduto.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacaoCategoriaProduto input = (Data.PdvEstacaoCategoriaProduto)parametros["Key"];
            Tables.PdvEstacaoCategoriaProduto bd = (Tables.PdvEstacaoCategoriaProduto)this.m_EntityManager.find
            (
                typeof(Tables.PdvEstacaoCategoriaProduto),
                new Object[]
                {
                    input.idPdvEstacaoCategoriaProduto
                }
            );

            if (input.produtoServico != null)
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else { }

            if (input.pdvEstacaoCategoria != null)
                bd.pdvEstacaoCategoria.idPdvEstacaoCategoria.value = input.pdvEstacaoCategoria.idPdvEstacaoCategoria;
            else { }

            bd.ordem.value = input.ordem;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvEstacaoCategoriaProduto bd = new Tables.PdvEstacaoCategoriaProduto();

            bd.idPdvEstacaoCategoriaProduto.value = ((Data.PdvEstacaoCategoriaProduto)parametros["Key"]).idPdvEstacaoCategoriaProduto;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.PdvEstacaoCategoriaProduto)bd).idPdvEstacaoCategoriaProduto.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvEstacaoCategoriaProduto)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PdvEstacaoCategoriaProduto)input).idPdvEstacaoCategoriaProduto = ((Tables.PdvEstacaoCategoriaProduto)bd).idPdvEstacaoCategoriaProduto.value;
                    ((Data.PdvEstacaoCategoriaProduto)input).ordem = ((Tables.PdvEstacaoCategoriaProduto)bd).ordem.value;
                    ((Data.PdvEstacaoCategoriaProduto)input).pdvEstacaoCategoria = (Data.PdvEstacaoCategoria)(new WS.CRUD.PdvEstacaoCategoria(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvEstacaoCategoria(),
                        ((Tables.PdvEstacaoCategoriaProduto)bd).pdvEstacaoCategoria,
                        level + 1
                    );
                    ((Data.PdvEstacaoCategoriaProduto)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.PdvEstacaoCategoriaProduto)bd).produtoServico,
                        level + 1
                    );

                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacaoCategoriaProduto result = (Data.PdvEstacaoCategoriaProduto)parametros["Key"];

            try
            {
                result = (Data.PdvEstacaoCategoriaProduto)this.preencher
                (
                    new Data.PdvEstacaoCategoriaProduto(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PdvEstacaoCategoriaProduto),
                        new Object[]
                        {
                            result.idPdvEstacaoCategoriaProduto
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlWhere = "",
                sqlOrderBy = "";

            int
                numRows = 0,
                offSet = -1;

            bool onlyCount = false;

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
                else { }

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
                else { }

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }
            }
            else { }

            Data.PdvEstacaoCategoriaProduto _input = (Data.PdvEstacaoCategoriaProduto)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idPdvEstacaoCategoriaProduto > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacaoCategoriaProduto.idPdvEstacaoCategoriaProduto = @idPdvEstacaoCategoriaProduto");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoCategoriaProduto", _input.idPdvEstacaoCategoriaProduto));
                    if (!sqlOrderBy.Contains("PdvEstacaoCategoriaProduto.idPdvEstacaoCategoriaProduto"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacaoCategoriaProduto.idPdvEstacaoCategoriaProduto");
                    else { }
                }
                else { }

                if (_input.pdvEstacaoCategoria != null)
                {
                    if (_input.pdvEstacaoCategoria.idPdvEstacaoCategoria > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacaoCategoriaProduto.idPdvEstacaoCategoria = @idPdvEstacaoCategoria");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoCategoria", _input.pdvEstacaoCategoria.idPdvEstacaoCategoria));
                        if (!sqlOrderBy.Contains("PdvEstacaoCategoriaProduto.idPdvEstacaoCategoria"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacaoCategoriaProduto.idPdvEstacaoCategoria");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "PdvEstacaoCategoriaProduto.* ") +
                    "from " +
                    (
                        "   PdvEstacaoCategoriaProduto PdvEstacaoCategoriaProduto "
                    ) +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
                );
                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacaoCategoriaProduto input = (Data.PdvEstacaoCategoriaProduto)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            Report.Base report = (Report.Base)parametros["Report"];

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String
                        _filter = (String)parametros["Filter"],
                        _keys = "";

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];

                        if (!_keys.Contains("[" + _key + "]"))
                        {
                            _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                            _keys += "[" + _key + "]";
                        }
                        else { }

                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.PdvEstacaoCategoriaProduto),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PdvEstacaoCategoriaProduto _data in
                    (System.Collections.Generic.List<Tables.PdvEstacaoCategoriaProduto>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacaoCategoriaProduto),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    //if (mode == "Roll")
                    //{
                    //_base = new Data.ResultadoConsulta();

                    //if (!_data.codConsCampo.codUsuario.isNull)
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codConsCampo.codUsuario.value;
                    //    ((Data.ResultadoConsulta)_base).descricao =
                    //    (
                    //        _data.descricao.value + "(" + _data.codConsCampo.idCadastro.nome.value + ")"
                    //    );
                    //}
                    //else
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                    //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                    //}
                    //}
                    //else
                    _base = (Data.Base)this.preencher(new Data.PdvEstacaoCategoriaProduto(), _data, level);

                    if (report != null)
                        report.ProcessRecord(_base);
                    else
                        result.Add(_base);
                }

                if (report != null)
                    report.ProcessRecord(null);
                else { }

                _fieldKeys.Clear();
                _fieldKeys = null;
                _select = null;
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
