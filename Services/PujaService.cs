using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Subastas_Final.Interfaces;

namespace Subastas_Final.Services
{
    internal class PujaService
    {
        private readonly IPujaRepository _pujaRepository;
        private static ISubastaRepository _subastaRepository = new SubastaRepository();

        public PujaService()
        {
            _pujaRepository = new PujaRepository();
        }

        public bool CrearPuja(int idSubasta, Postor postor, decimal montoIngresado)
        {
            if (postor == null)
                return false;

            var subasta = _subastaRepository.ObtenerSubastaPorId(idSubasta);

            if (subasta == null || !subasta.Estado)
                return false;

            if (DateTime.Now >= subasta.FechaFin)
                return false;

            if (subasta.Subastador.Email == postor.Email)
                return false;

            decimal montoMinimo = subasta.Pujas.Count == 0
                ? subasta.PrecioBase
                : subasta.MontoActual + subasta.PujaMinima;

            if (montoIngresado < montoMinimo)
                return false;

            var nuevaPuja = new Puja(postor, subasta, montoIngresado, DateTime.Now);

            _pujaRepository.CrearPuja(nuevaPuja);

            subasta.Pujas.Add(nuevaPuja);

            if (!subasta.Postores.Any(p => p.IdPostor == postor.IdPostor))
                subasta.Postores.Add(postor);

            subasta.MontoActual = montoIngresado;
            subasta.IdGanador = postor.IdPostor;

            _subastaRepository.ActualizarSubasta(subasta);

            return true;
        }

        public Puja ObtenerPujaPorId(int idPuja)
        {
            return _pujaRepository.ObtenerPujaPorId(idPuja);
        }

        public List<Puja> ObtenerPujasPorSubasta(int idSubasta)
        {
            return _pujaRepository
                .ObtenerTodasPujas()
                .Where(p => p.Subasta.IdSubasta == idSubasta)
                .OrderByDescending(p => p.Fecha)
                .ToList();
        }

        public List<Puja> ObtenerPujasPorPostor(int idPostor)
        {
            return _pujaRepository
                .ObtenerTodasPujas()
                .Where(p => p.Postor.IdPostor == idPostor)
                .OrderByDescending(p => p.Fecha)
                .ToList();
        }

        public void ActualizarPuja(Puja puja)
        {
            _pujaRepository.ActualizarPuja(puja);
        }

        public void EliminarPuja(int idPuja)
        {
            _pujaRepository.EliminarPuja(idPuja);
        }
    }
}