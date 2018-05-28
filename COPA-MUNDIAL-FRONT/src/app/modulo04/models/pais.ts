import { I18nEquipo } from './i18n_equipo';

export class Pais {
    private _iso: string;
    private _nombre: I18nEquipo;
    private _urlBandera: string;

    // getters y setters de la clase
    get getIso(): string {
        return this._iso;
    }

    get getNombre(): I18nEquipo {
        return this._nombre;
    }

    get getUrlBandera(): string {
        return this._urlBandera;
    }

    set setIso(iso: string) {
        this._iso = iso;
    }

    set setNombre(nombre: I18nEquipo ) {
        this._nombre = nombre;
    }

    set setUrlBandera(url: string) {
        this._urlBandera = url;
    }
}
