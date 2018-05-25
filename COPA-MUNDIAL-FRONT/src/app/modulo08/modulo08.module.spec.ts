import { Modulo08Module } from './modulo08.module';

describe('Modulo08Module', () => {
  let modulo08Module: Modulo08Module;

  beforeEach(() => {
    modulo08Module = new Modulo08Module();
  });

  it('should create an instance', () => {
    expect(modulo08Module).toBeTruthy();
  });
});
