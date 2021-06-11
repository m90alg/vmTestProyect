
CREATE DATABASE vmtest
    WITH 
    OWNER = vmuser
    ENCODING = 'UTF8'
    LC_COLLATE = 'Spanish_Guatemala.1252'
    LC_CTYPE = 'Spanish_Guatemala.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;
	
CREATE SEQUENCE public."Transactions_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;

ALTER SEQUENCE public."Transactions_Id_seq"
    OWNER TO vmuser;
	
CREATE TABLE public."Transactions"
(
    "Id" integer NOT NULL DEFAULT nextval('"Transactions_Id_seq"'::regclass),
    "Usuario" character varying(25) COLLATE pg_catalog."default" NOT NULL,
    "Moneda" character varying(10) COLLATE pg_catalog."default" NOT NULL,
    "Monto" numeric(10,2) NOT NULL,
    "Total" numeric(10,2) NOT NULL,
    "Fecha" date NOT NULL,
    CONSTRAINT "Transactions_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE public."Transactions"
    OWNER to vmuser;