export class RespuestaApi<T> {
    private _codigo: number;
    private _mensaje: T;
    private _error: string;

    get codigo(): number {
        return this._codigo;
    }

    set codigo(codigo: number) {
        this._codigo = codigo;
    }

    get mensaje(): T {
        return this._mensaje;
    }

    set mensaje(mensaje: T) {
        this._mensaje = mensaje;
    }

    get error(): string {
        return this._error;
    }

    set error(error: string) {
        this._error = error;
    }
}
