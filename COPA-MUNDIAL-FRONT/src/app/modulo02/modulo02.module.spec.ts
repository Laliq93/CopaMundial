import { Modulo02Module } from './modulo02.module';

describe('Modulo02Module', () => {
  let modulo02Module: Modulo02Module;

  beforeEach(() => {
    modulo02Module = new Modulo02Module();
  });

  it('should create an instance', () => {
    expect(modulo02Module).toBeTruthy();
  });
});
