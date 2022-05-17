using System;

namespace csharp_agenzia
{
    public class Agenzia
    {
        private string nome;
        public List<Immobile> lstImmobile;

        public Agenzia(string nome)
        {
            this.nome = nome;
            this.lstImmobile = new List<Immobile>();
        }

        public void AddBox(string codice, string indirizzo, string CAP, string citta, uint superficieMQuadrati, uint numeriPostiAuto)
        {
            Box newBox = new Box(codice, indirizzo, CAP, citta, superficieMQuadrati, numeriPostiAuto);
            this.lstImmobile.Add(newBox);
        }

        public void AddAppartamento(string codice, string indirizzo, string CAP, string citta, uint superficieMQuadrati, uint numeroVani, uint numeroBagni)
        {
            Appartamento newAppartamento = new Appartamento(codice, indirizzo, CAP, citta, superficieMQuadrati, numeroVani, numeroBagni);
            this.lstImmobile.Add(newAppartamento);
        }

        internal void AddListaImmobili(List<Immobile> lstImmobili)
        {
            foreach (Immobile m in lstImmobili)
            {
                this.lstImmobile.Add(m);
            }
        }

        public void AddVilla(string codice, string indirizzo, string CAP, string citta, uint superficieMQuadrati, uint numeroVani, uint numeroBagni, uint superficieMQuadratiGiardino)
        {
            Villa newVilla = new Villa(codice, indirizzo, CAP, citta, superficieMQuadrati, numeroVani, numeroBagni, superficieMQuadratiGiardino);
            this.lstImmobile.Add(newVilla);
        }

        public List<Immobile> CercaImmobili(string key)
        {
            return this.lstImmobile.FindAll(t => t.Contains(key));
        }
    }

    public class Immobile
    {
        protected string codice;
        protected string indirizzo;
        protected string CAP;
        protected string citta;
        protected uint superficieMQuadrati;

        public Immobile(string codice, string indirizzo, string CAP, string citta, uint superficieMQuadrati)
        {
            this.codice = codice;
            this.indirizzo = indirizzo;
            this.CAP = CAP;
            this.citta = citta;
            this.superficieMQuadrati = superficieMQuadrati;
        }

        public virtual string Write()
        {
            return String.Format("CODICE IMMOBILE: {0}\nLOCALITA': {1}, {2} ({3})\nSUPERFICIE: {4}mq\n", this.codice, this.indirizzo, this.citta, this.CAP, this.superficieMQuadrati);
        }

        public virtual bool Contains(string key)
        {
            if (this.codice.Contains(key)) return true;
            else if (this.indirizzo.Contains(key)) return true;
            else if (this.CAP.Contains(key)) return true;
            else if (this.citta.Contains(key)) return true;
            else if (this.superficieMQuadrati.ToString().Contains(key)) return true;
            else return false;
        }
    }

    public class Box : Immobile
    {
        private uint numeroPostiAuto;

        public Box(string codice, string indirizzo, string CAP, string citta, uint superficieMQuadrati, uint numeriPostiAuto) : base(codice, indirizzo, CAP, citta, superficieMQuadrati) 
        { 
            this.numeroPostiAuto = numeriPostiAuto;
        }

        public override string ToString()
        {
            return String.Format("\n**dettagli box**\n{0}", Write());
        }

        public override string Write()
        {
            return String.Format("{0}NUMERO POSTI AUTO: {1}", base.Write(), this.numeroPostiAuto);
        }

        public override bool Contains(string key)
        {
            if (base.Contains(key)) return true;
            else if (this.numeroPostiAuto.ToString().Contains(key)) return true;
            else return false;
        }
    }

    public class Appartamento : Immobile
    {
        private uint numeroVani;
        private uint numeroBagni;

        public Appartamento(string codice, string indirizzo, string CAP, string citta, uint superficieMQuadrati, uint numeroVani, uint numeroBagni) : base(codice, indirizzo, CAP, citta, superficieMQuadrati)
        {
            this.numeroVani = numeroVani;
            this.numeroBagni = numeroBagni;
        }

        public override string ToString()
        {
            return String.Format("\n**dettagli appartamento**\n{0}", Write());
        }

        public override string Write()
        {
            return String.Format("{0}NUMERO DI BAGNI: {1}\nNUMERO DI VANI: {2}\n", base.Write(), this.numeroBagni, this.numeroVani);
        }

        public override bool Contains(string key)
        {
            if (base.Contains(key)) return true;
            else if (this.numeroVani.ToString().Contains(key)) return true;
            else if (this.numeroBagni.ToString().Contains(key)) return true;
            else return false;
        }
    }

    public class Villa : Appartamento
    {
        private uint superficieMQuadratiGiardino;

        public Villa(string codice, string indirizzo, string CAP, string citta, uint superficieMQuadrati, uint numeroVani, uint numeroBagni, uint superficieMQuadratiGiardino) : base(codice, indirizzo, CAP, citta, superficieMQuadrati, numeroVani, numeroBagni)
        {
            this.superficieMQuadratiGiardino = superficieMQuadratiGiardino;
        }

        public override string ToString()
        {
            return String.Format("\n**dettagli villa**\n{0}", Write());
        }

        public override string Write()
        {
            return String.Format("{0}SUPERFICIE GIARDINO: {1} mq", base.Write(), this.superficieMQuadratiGiardino);
        }

        public override bool Contains(string key)
        {
            if (base.Contains(key)) return true;
            else if (this.superficieMQuadratiGiardino.ToString().Contains(key)) return true;
            else return false;
        }
    }
}