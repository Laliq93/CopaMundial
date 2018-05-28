import { I18nEquipo } from './i18n_equipo';

export class Pais {
    private _iso: string;
    private _nombre: I18nEquipo;
    private _urlBandera: string;

    // getters y setters de la clase
    get iso(): string {
        return this._iso;
    }

    get nombre(): I18nEquipo {
        return this._nombre;
    }

    get urlBandera(): string {
        return this._urlBandera;
    }

    set iso(iso: string) {
        this._iso = iso;
    }

    set nombre(nombre: I18nEquipo ) {
        this._nombre = nombre;
    }

    set urlBandera(url: string) {
        this._urlBandera = url;
    }
}
