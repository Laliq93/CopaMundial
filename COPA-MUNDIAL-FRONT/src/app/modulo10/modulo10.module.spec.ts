import { Modulo10Module } from './modulo10.module';

describe('Modulo10Module', () => {
  let modulo10Module: Modulo10Module;

  beforeEach(() => {
    modulo10Module = new Modulo10Module();
  });

  it('should create an instance', () => {
    expect(modulo10Module).toBeTruthy();
  });
});
