import { Modulo06Module } from './modulo06.module';

describe('Modulo06Module', () => {
  let modulo06Module: Modulo06Module;

  beforeEach(() => {
    modulo06Module = new Modulo06Module();
  });

  it('should create an instance', () => {
    expect(modulo06Module).toBeTruthy();
  });
});
